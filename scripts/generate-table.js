const fs = require('fs')

// 语言标题
const langTitleMap = {
  bash: 'Bash',
  c: 'C',
  cpp: 'C++',
  csharp: 'C#',
  golang: 'Go',
  java: 'Java',
  javascript: 'JavaScript',
  kotlin: 'Kotlin',
  mysql: 'MySQL',
  php: 'PHP',
  python: 'Python 2',
  python3: 'Python 3',
  ruby: 'Ruby',
  rust: 'Rust',
  scala: 'Scala',
  swift: 'Swift',
  typescript: 'TypeScript',
}

const file = fs.readFileSync('README.md', { encoding: 'utf-8' })
const langs = fs.readdirSync('src')
let content = '\n'

// 生成表头
content += '| ID | 标题 | 难度 |'
for (let lang of langs) content += ` ${langTitleMap[lang]} |`
content += '\n|:---:|:----|:---:|' + ':---:|'.repeat(langs.length) + '\n'

// { [problemName]: { [lang]: ['S1.cs', 'S2.cs', ...] } }
const problems = {}

// 读取目录信息
for (let lang of langs)
  for (let problemName of fs.readdirSync(`src/${lang}`)) {
    if (!problemName.includes('_')) continue

    const files = fs
      .readdirSync(`src/${lang}/${problemName}`)
      .filter((filename) => getSolutionNum(filename))

    problems[problemName] = Object.assign(problems[problemName] ?? {}, {
      [lang]: files,
    })
  }

// 根据序号排序
const sorted = Object.keys(problems).sort(
  (a, b) => parseInt(a.split('_')[0]) - parseInt(b.split('_')[0])
)

// 生成表内容
for (let problemName of sorted) {
  const arr = problemName.split('_')
  content += `| ${arr[0]} | ${arr[2]} | ${getLight(arr[1])} |`

  for (let lang of langs) {
    if (!problems[problemName][lang]) {
      content += ` _N/A_ |`
      continue
    }

    const solutionLinks = problems[problemName][lang].map((filename) => {
      const name = filename.split('.')[0]
      const desc = name.split('_')[1]
      return `[${desc ?? name}](./src/${lang}/${problemName}/${filename})`
    })

    content += ` ${solutionLinks.join('、')} |`
  }
  content += '\n'
}

// 写入文件
fs.writeFileSync(
  'README.md',
  file.replace(/(?<=<!-- Start Table -->).*(?=<!-- End Table -->)/s, content)
)

function getLight(val) {
  switch (val) {
    case 'easy':
      return '🟢'
    case 'medium':
      return '🟡'
    case 'hard':
      return '🔴'
  }
}

function getSolutionNum(filename) {
  const match = filename.match(/(?<=S)\d+/)
  return match ? parseInt(match[0]) : null
}
