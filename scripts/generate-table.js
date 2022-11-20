const fs = require('fs')

let content = fs.readFileSync('README.md', { encoding: 'utf-8' })
const langs = fs.readdirSync('src')

// 去除原本内容
content = content.replace(/(?<=## 已完成的题解).*/s, '\n\n')

// 生成表头
content += '| 题解 |'
for (let lang of langs)
  content += ` ${lang
    .replace('csharp', 'C#')
    .replace('typescript', 'TypeScript')} |`
content += '\n|:----|' + ':---:|'.repeat(langs.length) + '\n'

const problems = {}

// 读取目录信息
for (let lang of langs)
  for (let problemName of fs.readdirSync(`src/${lang}`)) {
    if (!problemName.includes('-')) continue
    if (problems[problemName]) {
      problems[problemName][lang] = true
    } else {
      problems[problemName] = { [lang]: true }
    }
  }

// 根据序号排序
var sorted = Object.keys(problems).sort(
  (a, b) => parseInt(a.split('-')[0]) - parseInt(b.split('-')[0])
)

// 生成表内容
for (let problemName of sorted) {
  content += `| ${problemName} |`
  for (let lang of langs) {
    content += ` ${getLight(problems[problemName][lang])} |`
  }
  content += '\n'
}

// 写入文件
fs.writeFileSync('README.md', content)

function getLight(val) {
  return val ? '🟢' : '🔴'
}
