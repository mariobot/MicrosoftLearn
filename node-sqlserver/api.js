var Db = require('./dboperations')
var Order = require('./order')
var express = require('express')
var bodyParser = require('body-parser')
var cors = require('cors')
var app = express()
var router = express.Router()

app.use(bodyParser.urlencoded({ extended: true}))
app.use(bodyParser.json())
app.use(cors())

app.use('/api', router)

app.use((request, response, next) =>{
    console.log('Middleware')
    next()
})

app.route('/').get((request, response) =>{
    response.status(200).end("Welcome to node-msql API")
})

router.route('/orders').get((request,response) =>{    
    try{
        Db.getOrders().then((data) => {
            response.json(data[0])
        })
    }
    catch(error){
        console.error(error)
    }
})

router.route('/orders/:id').get((request, response) => {
    Db.getOrder(request.params.id).then((data) => {
        response.json(data[0])
    })
})

router.route('/orders').post((request,response) =>{
    let order = { ...request.body }
    Db.addOrder(order).then((data) => {
        response.status(201).json(data)
    })
})

var port = process.env.PORT ?? 31500
app.listen(port)
console.log(`API listenin in the route: http://localhost:${port}/api`)