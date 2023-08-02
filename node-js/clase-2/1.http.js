const http = require('node:http')
const fs = require('node:fs')

const desiredPort = process.env.PORT ?? 3000

const processRequest = (req, res) =>{
    res.setHeader('Content-Type', 'text/plain; charset=uft-8')
    if(req.url === '/'){
        res.statusCode = 200 // Ok
        res.end('Hi to my web')
    } else if(req.url === '/image'){
    fs.readFile('./node.png', (err, data) =>{
        if(err){
            res.statusCode = 500
            res.end('500 internal error')
        }else{
            res.setHeader('Content-Type', 'image/png')
            res.end(data)
        }
    })
    }
    else if(req.url === '/contacto')
    {
        res.statusCode = 200 // Ok        
        res.end('Contacto')
    } else{
        res.statusCode = 404
        res.end('404')
    }
}


const server = http.createServer(processRequest)

server.listen(desiredPort, () =>{
    console.log(`server listening on port http://localhost:${desiredPort}`)
})