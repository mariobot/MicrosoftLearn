// Solo para modulos que no tienen promesas nativas
//const { promisify } = require('node:util')
//const readFilePromise = promisify(fs.readFile)

const fs = require('node:fs')
const { promisify } = require('node:util')


console.log('Leyendo el primer archivo')
fs.readFile('./file.txt', 'utf-8', (err, text ) => {
    console.log(text)
})

console.log('Hacer cosas mientras leen el archivo')

console.log('Leyendo el segundo archivo')
fs.readFile('./file2.txt', 'utf-8', (err, text) =>{
    console.log(text)
})

