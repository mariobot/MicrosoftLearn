var config = require('./dbconfig')
var sql = require('mssql')

async function getOrders(){
    try{
        let pool = await sql.connect(config)
        let orders = await pool.request().query("SELECT * FROM Orders")
        return orders.recordsets
    }
    catch(error){
        console.error(error)
    }
}

async function getOrder(productId){
    try{
        let pool = await sql.connect(config)
        let order = await pool.request()
        .input('input_parameter', sql.Int, productId)
        .query("SELECT * FROM Orders WHERE Id = @input_parameter")
        return order.recordsets
    }
    catch(error){
        console.error(error)
    }
}

async function addOrder(order){
    try{
        let pool = await sql.connect(config)
        let insertOrder = await pool.request()        
        .input('Title', sql.NVarChar, order.Title)
        .input('Quantity',sql.Int,order.Quantity)
        .input('Message',sql.NVarChar,order.Message)
        .input('City',sql.NVarChar,order.City)
        .query('INSERT INTO Orders (Title,Quantity,Message,City) VALUES (@Title,@Quantity,@Message,@City)')                
        return order
    }
    catch(error){
        console.error(error)
    }
}

async function deleteOrder(orderId){
    try{
        let pool = await sql.connect(config)
        let deleteOrder = await pool.request()        
        .input('Id', sql.Int, orderId)
        .query('DELETE FROM Orders WHERE Id = @Id')
        let deleted = deleteOrder.rowsAffected == 1 
        return deleted
    }
    catch(error){
        console.error(error)
    }
}

async function updateOrder(order){
    try{
        let pool = await sql.connect(config)
        let updateOrder = await pool.request()
        .input('Id', sql.Int, order.Id)        
        .input('Title', sql.NVarChar, order.Title)
        .input('Quantity',sql.Int,order.Quantity)
        .input('Message',sql.NVarChar,order.Message)
        .input('City',sql.NVarChar,order.City)
        .query('UPDATE Orders SET Title=@Title, Quantity=@Quantity, Message=@Message, City=@City WHERE Id=@Id')                
        updated = updateOrder.rowsAffected == 1
        return updated
    }
    catch(error){
        console.error(error)
    }
}

module.exports = {
    getOrders: getOrders,
    getOrder: getOrder,
    addOrder: addOrder,
    deleteOrder: deleteOrder,
    updateOrder: updateOrder
}