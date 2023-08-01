const path = require('node:path')

// barra separadora de carpetas segun SO
console.log(path.sep)

const filePath = path.join('content', 'subfolder', 'test.txt')
console.log(filePath)

const base = path.basename('/tmp/folder/password.txt')
console.log(base)

const filename = path.basename('/tmp/folder/password.txt', '.txt')
console.log(filename)

const extension = path.extname('password.txt')
console.log(extension)