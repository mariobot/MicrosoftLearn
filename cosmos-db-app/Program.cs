using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace cosmos_db_app
{
    class Program
    {
        private DocumentClient client;

        static void Main(string[] args)
        {
            Console.WriteLine("Inicializando la Base de datos");

            try
            {
                Program p = new Program();
                p.BasicOperations().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} Un error a ocurrido: {1}, Mensaje: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Mensje: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("Fin del demo , unda una tecla para salir.");
                Console.ReadKey();
            }
        }

        private async Task BasicOperations()
        {
            this.client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["accountEndpoint"]), ConfigurationManager.AppSettings["accountKey"]);

            await this.client.CreateDatabaseIfNotExistsAsync(new Database { Id = "db" });

            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("db"), new DocumentCollection { Id = "WebCustomers" });

            Console.WriteLine("Validacion de la coleccion de la base de datos completa");

            User yanhe = new User
            {
                Id = "1",
                UserId = "yanhe",
                LastName = "He",
                FirstName = "Yan",
                Email = "yanhe@contoso.com",
                OrderHistory = new OrderHistory[]
                    {
                        new OrderHistory {
                            OrderId = "1000",
                            DateShipped = "08/17/2018",
                            Total = "52.49"
                        }
                    },
                ShippingPreference = new ShippingPreference[]
                    {
                            new ShippingPreference {
                                    Priority = 1,
                                    AddressLine1 = "90 W 8th St",
                                    City = "New York",
                                    State = "NY",
                                    ZipCode = "10001",
                                    Country = "USA"
                            }
                    },
            };

            await this.CreateUserDocumentIfNotExists("db", "WebCustomers", yanhe);

            User nelapin = new User
            {
                Id = "2",
                UserId = "nelapin",
                LastName = "Pindakova",
                FirstName = "Nela",
                Email = "nelapin@contoso.com",
                Dividend = "8.50",
                OrderHistory = new OrderHistory[]
                {
                    new OrderHistory {
                        OrderId = "1001",
                        DateShipped = "08/17/2018",
                        Total = "105.89"
                    }
                },
                ShippingPreference = new ShippingPreference[]
                {
                    new ShippingPreference {
                            Priority = 1,
                            AddressLine1 = "505 NW 5th St",
                            City = "New York",
                            State = "NY",
                            ZipCode = "10001",
                            Country = "USA"
                    },
                    new ShippingPreference {
                            Priority = 2,
                            AddressLine1 = "505 NW 5th St",
                            City = "New York",
                            State = "NY",
                            ZipCode = "10001",
                            Country = "USA"
                    }
                },
                Coupons = new CouponsUsed[]
                {
                    new CouponsUsed{
                        CouponCode = "Fall2018"
                    }
                }
            };

            await this.CreateUserDocumentIfNotExists("db", "WebCustomers", nelapin);

            await this.ReadUserDocument("db", "WebCustomers", yanhe);

            yanhe.LastName = "Suh";
            await this.ReplaceUserDocument("db", "WebCustomers", yanhe);

            await this.DeleteUserDocument("db", "WebCustomers", yanhe);

            this.ExecuteSimpleQuery("Users", "WebCustomers");

            await this.RunStoredProcedure("Users", "WebCustomers", yanhe);

        }

        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        private async Task CreateUserDocumentIfNotExists(string databaseName, string collectionName, User user)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, user.Id), new RequestOptions { PartitionKey = new PartitionKey(user.UserId) });
                this.WriteToConsoleAndPromptToContinue("User {0} already exists in the database", user.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), user);
                    this.WriteToConsoleAndPromptToContinue("Created User {0}", user.Id);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task ReadUserDocument(string databaseName, string collectionName, User user)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, user.Id), new RequestOptions { PartitionKey = new PartitionKey(user.UserId) });
                this.WriteToConsoleAndPromptToContinue("Read user {0}", user.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    this.WriteToConsoleAndPromptToContinue("User {0} not read", user.Id);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task ReplaceUserDocument(string databaseName, string collectionName, User updatedUser)
        {
            try
            {
                await this.client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, updatedUser.Id), updatedUser, new RequestOptions { PartitionKey = new PartitionKey(updatedUser.UserId) });
                this.WriteToConsoleAndPromptToContinue("Replaced last name for {0}", updatedUser.LastName);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    this.WriteToConsoleAndPromptToContinue("User {0} not found for replacement", updatedUser.Id);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task DeleteUserDocument(string databaseName, string collectionName, User deletedUser)
        {
            try
            {
                await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, deletedUser.Id), new RequestOptions { PartitionKey = new PartitionKey(deletedUser.UserId) });
                Console.WriteLine("Deleted user {0}", deletedUser.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    this.WriteToConsoleAndPromptToContinue("User {0} not found for deletion", deletedUser.Id);
                }
                else
                {
                    throw;
                }
            }
        }

        private void ExecuteSimpleQuery(string databaseName, string collectionName)
        {
            // Set some common query options
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true };

            // Here we find nelapin via their LastName
            IQueryable<User> userQuery = this.client.CreateDocumentQuery<User>(
                    UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
                    .Where(u => u.LastName == "Pindakova");

            // The query is executed synchronously here, but can also be executed asynchronously via the IDocumentQuery<T> interface
            Console.WriteLine("Running LINQ query...");
            foreach (User user in userQuery)
            {
                Console.WriteLine("\tRead {0}", user);
            }

            // Now execute the same query via direct SQL
            IQueryable<User> userQueryInSql = this.client.CreateDocumentQuery<User>(
                    UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                    "SELECT * FROM User WHERE User.lastName = 'Pindakova'", queryOptions );

            Console.WriteLine("Running direct SQL query...");
            foreach (User user in userQueryInSql)
            {
                    Console.WriteLine("\tRead {0}", user);
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        public async Task RunStoredProcedure(string databaseName, string collectionName, User user)
        {
            await client.ExecuteStoredProcedureAsync<string>(UriFactory.CreateStoredProcedureUri(databaseName, collectionName, "UpdateOrderTotal"), new RequestOptions { PartitionKey = new PartitionKey(user.UserId) });
            Console.WriteLine("Stored procedure complete");
        }



        





    }
}
