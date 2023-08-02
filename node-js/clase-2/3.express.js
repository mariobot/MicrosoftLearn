const express = require('express')
const dittoJson = require('./pokemon/ditto.json')
const app = express()

app.disable('x-powered-by')

const PORT = process.env.PORT ?? 3000

app.use((req, res, next) =>{
    // use a myddleware to execute actions after of before ar request
    console.log('Myddleware executing')
    // Use to set the next action

    if(req.method !== 'POST') return next()    
    if(req.headers['content-type'] != 'application/json') return next()

    let body = ''
    req.on('data', chunk =>{
        body += chunk.toString()
    })

    req.on('end', () =>{        
        const data = JSON.parse(body)
        data.timestamp = Date.now() 
        req.body = data
        next()
    })
})

app.get('/pokemon/ditto',(req,res) =>{
    res.status(201).json(dittoJson)
})

app.post('/pokemon', (req,res) =>{
    res.status(201).json(req.body)
})

app.use((req, res) =>{
    res.status(404).send('<h1>400</h1>')
})

app.listen(PORT, () =>{
    console.log(`server listening on port http://localhost:${PORT}`)
})

