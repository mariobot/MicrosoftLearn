using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_webapi.Models
{
    public class ProductRepository
    {
        private string connString;

        public ProductRepository() 
        {
            connString = @"Data Source=MBOTERO\MBOTERO;Initial Catalog=dapper;Integrated Security=True";
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(connString); }        
        }

        public void Add(Product product) 
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO PRODUCTS (Name, Quantity,Price) VALUES(@Name,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, product);
            }        
        }

        public IEnumerable<Product> GetAll() 
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM PRODUCTS";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM PRODUCTS WHERE ProductId = @Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM PRODUCTS WHERE ProductId = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Product product)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET Name = @Name, Quantity = @Quantity, Price = @Price WHERE ProductId = @ProductId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, product);
            }
        }
    }
}
