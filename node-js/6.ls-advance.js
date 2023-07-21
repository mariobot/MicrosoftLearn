const fs = require('node:fs/promises')

const folder = process.argv[2] ?? '.'

async function ls (folder){
    let files
    try {
         files = await fs.readdir(folder)
    } catch (error) {
        console.error('No se pudo leer el directorio', error)
        process.exit(1)
    }
}

fs.readdir(folder, (err, files) =>{
    if(err){
        console.error('Error al leer el directorio ', err)
        return;
    }

    files.forEach(file =>{
        console.log(file)
    })
})