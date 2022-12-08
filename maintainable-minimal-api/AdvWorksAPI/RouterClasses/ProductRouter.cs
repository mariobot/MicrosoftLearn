using AdvWorksAPI.Components;
using AdvWorksAPI.EntityClasses;

namespace AdvWorksAPI.RouterClasses
{
    public class ProductRouter : RouterBase
    {
        private readonly ILogger<ProductRouter> logger;

        public ProductRouter(ILogger<ProductRouter> logger)
        {
            UrlFragment = "product";
            this.logger = logger;
        }

        /// <summary>
        /// Add routes
        /// </summary>
        /// <param name="app">A WebApplication object</param>
        public override void AddRoutes(WebApplication app)
        {
            app.MapGet($"/{UrlFragment}", () => Get());
            app.MapGet($"/{UrlFragment}/{{id:int}}", (int id) => Get(id));
            app.MapPost($"/{UrlFragment}", (Product entity) => Post(entity));
            app.MapPut($"/{UrlFragment}/{{id:int}}", (int id, Product entity) => Put(id, entity));
            app.MapDelete($"/{UrlFragment}/{{id:int}}", (int id) => Delete(id));
        }


        /// <summary>
        /// GET a collection of data
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Get()
        {
            logger.LogInformation("Getting all products");
            return Results.Ok(GetAll());
        }

        /// <summary>
        /// GET a single row of data
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Get(int id)
        {
            // Locate a single row of data
            Product? current = GetAll().Find(p => p.ProductID == id);
            if (current != null)
            {
                return Results.Ok(current);
            }
            else
            {
                return Results.NotFound();
            }
        }

        /// <summary>
        /// INSERT new data
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Post(Product entity)
        {
            // Generate a new ID
            entity.ProductID = GetAll().Max(p => p.ProductID) + 1;

            // TODO: Insert into data store

            // Return the new object created
            return Results.Created($"/{UrlFragment}/{entity.ProductID}", entity);
        }

        /// <summary>
        /// UPDATE existing data
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Put(int id, Product entity)
        {
            IResult ret;

            // Locate a single row of data
            Product? current = GetAll().Find(p => p.ProductID == id);

            if (current != null)
            {
                // TODO: Update the entity
                current.Name = entity.Name;
                current.Color = entity.Color;
                current.ListPrice = entity.ListPrice;

                // TODO: Update the data store

                // Return the updated entity
                ret = Results.Ok(current);
            }
            else
            {
                ret = Results.NotFound();
            }

            return ret;
        }

        /// <summary>
        /// DELETE a single row
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Delete(int id)
        {
            IResult ret;

            // Locate a single row of data
            Product? current = GetAll().Find(p => p.ProductID == id);

            if (current != null)
            {
                // TODO: Delete data from the data store
                GetAll().Remove(current);

                // Return NoContent
                ret = Results.NoContent();
            }
            else
            {
                ret = Results.NotFound();
            }

            return ret;
        }



        /// <summary>
        /// Get a collection of Product objects
        /// </summary>
        /// <returns>A list of Product objects</returns>
        protected virtual List<Product> GetAll()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductID = 706,
                    Name = "HL Road Frame - Red, 58",
                    Color = "Red",
                    ListPrice = 1500.0000m
                },
                new Product
                {
                    ProductID = 707,
                    Name = "Sport-100 Helmet, Red",
                    Color = "Red",
                    ListPrice = 34.9900m
                },
                new Product
                {
                    ProductID = 708,
                    Name = "Sport-100 Helmet, Black",
                    Color = "Black",
                    ListPrice = 34.9900m
                },
                new Product
                {
                    ProductID = 709,
                    Name = "Mountain Bike Socks, M",
                    Color = "White",
                    ListPrice = 9.5000m
                },
                new Product
                {
                    ProductID = 710,
                    Name = "Mountain Bike Socks, L",
                    Color = "White",
                    ListPrice = 9.5000m
                }
            };
        }
    }
}
