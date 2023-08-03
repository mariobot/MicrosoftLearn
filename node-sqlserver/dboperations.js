var config = require('./dbconfig')
var sql = require('mssql')

async function getOrders(){
    try{
        let pool = await sql.connect(config)
        let products = await pool.request().query("SELECT * FROM Orders")
        return products.recordsets
    }
    catch(error){
        console.log(error)
    }
}

async function getOrder(productId){
    try{
        let pool = await sql.connect(config)
        let product = await pool.request()
        .input('input_parameter', sql.Int, productId)
        .query("SELECT * FROM Orders WHERE Id = @input_parameter")
        return product.recordsets
    }
    catch(error){
        console.log(error)
    }
}

async function addOrder(order){
    try{
        let pool = await sql.connect(config)
        let insertProduct = await pool.request()        
        .input('Title', sql.NVarChar, order.Title)
        .input('Quantity',sql.Int,order.Quantity)
        .input('Message',sql.NVarChar,order.Message)
        .input('City',sql.NVarChar,order.City)
        .query('INSERT INTO Orders (Title,Quantity,Message,City) VALUES (@Title,@Quantity,@Message,@City)')                
        return order
    }
    catch(error){
        console.log(error)
    }
}

module.exports = {
    getOrders: getOrders,
    getOrder: getOrder,
    addOrder: addOrder
}