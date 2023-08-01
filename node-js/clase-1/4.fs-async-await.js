// Solo para modulos que no tienen promesas nativas
//const { promisify } = require('node:util')
//const readFilePromise = promisify(fs.readFile)

const { readFile } = require('node:fs/promises');

// IIFE Inmediatly Invoked Function Expression
( async () =>{
    console.log('Leyendo el primer archivo')
    const text = await readFile('./file.txt', 'utf-8')
    console.log('primer texto', text)

    console.log('Hacer cosas mientras leen el archivo')

    console.log('Leyendo el segundo archivo')
    const secondText = await readFile('./file2.txt', 'utf-8')
    console.log('segundo texto', secondText)
})()



