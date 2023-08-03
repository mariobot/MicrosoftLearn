var config = require('./dbconfig')
var sql = require('mssql')

async function getOrders(){
    try{
        let pool = await sql.connect(config)
        let products = await pool.request().query("SELECT * FROM Orders")
        return products
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
        return product
    }
    catch(error){
        console.log(error)
    }
}

async function addOrder(order){
    try{
        let pool = await sql.connect(config)
        let insertProduct = await pool.request()
        .input('Id', sql.Int, order.Id)
        .input('Title', sql.NVarChar, order.Title)
        .input('Quantity',sql.Int,order.Quantity)
        .input('Message',sql.NVarChar,order.Message)
        .input('City',sql.NVarChar,order.City)
        .query('INSERT INTO Orders (Id,Title,Quantity,Message,City) VALUES (@Id,@Title,@Quantity,@Message,@City)')
        return insertProduct.recordsets
    }
    catch(error){
        console.log(error)
    }
}

module.exports = {
    getOrders,
    getOrder,
    addOrder
}