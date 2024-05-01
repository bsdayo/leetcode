$langs = @{
    bash       = 'Bash'
    c          = 'C'
    cpp        = 'C++'
    csharp     = 'C#'
    golang     = 'Go'
    java       = 'Java'
    javascript = 'JavaScript'
    kotlin     = 'Kotlin'
    mysql      = 'MySQL'
    php        = 'PHP'
    python     = 'Python 2'
    python3    = 'Python 3'
    ruby       = 'Ruby'
    rust       = 'Rust'
    scala      = 'Scala'
    swift      = 'Swift'
    typescript = 'TypeScript'
}
$difficulties = @{
    easy   = '🟢'
    medium = '🟡'
    hard   = '🔴'
}
$readmePath = "$PSScriptRoot/../README.md"
$srcDir = "$PSScriptRoot/../src"

$content = "`n"

# 生成表头
$content += "| ID | 难度 | 标题 | 题解 |`n"
$content += "|:---:|:---:|:---:|:---:|`n"

$problems = Get-ChildItem $srcDir -Directory `
| ForEach-Object { Get-ChildItem $_.FullName -Directory -Filter '*_*' } `
| Group-Object Name `
| ForEach-Object {
    $parts = $_.Name -split '_'
    [pscustomobject]@{
        Id         = [int]$parts[0]
        Difficulty = $parts[1]
        Title      = $parts[2]
        Name       = $_.Name
        Languages  = $_.Group | ForEach-Object {
            [pscustomobject]@{
                Id        = $_.Parent.Name
                Name      = $langs[$_.Parent.Name]
                Solutions = Get-ChildItem $_.FullName -File
            }
        } 
    } } `
| Sort-Object Id

Write-Verbose "Problems found:"
Write-Verbose ($problems | Out-String)

foreach ($problem in $problems) {
    $solutions = $problem.Languages | ForEach-Object {
        $lang = $_
        "**$($lang.Name)**: $(($_.Solutions | ForEach-Object { "[$($_.BaseName)](src/$($lang.Id)/$($problem.Name)/$($_.Name))" }) -join ' ')"
    }
    $content += "| $($problem.Id) | $($difficulties[$problem.Difficulty]) | $($problem.Title) | $($solutions -join '<br/>') |`n"
}

Write-Verbose "Writting generated table to file..."
(Get-Content -Raw $readmePath) -replace '(?s)(?<=<!-- Start Table -->).*(?=<!-- End Table -->)', $content | Out-File -Encoding utf8 -NoNewline $readmePath