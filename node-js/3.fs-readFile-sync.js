// Solo para modulos que no tienen promesas nativas
//const { promisify } = require('node:util')
//const readFilePromise = promisify(fs.readFile)

const fs = require('node:fs')

console.log('Leyendo el primer archivo')
const text = fs.readFileSync('./file.txt', 'utf-8')
console.log('primer texto', text)

console.log('Hacer cosas mientras leen el archivo')

console.log('Leyendo el segundo archivo')
const secondText = fs.readFileSync('./file2.txt', 'utf-8')
console.log('Segundo texto', secondText)

