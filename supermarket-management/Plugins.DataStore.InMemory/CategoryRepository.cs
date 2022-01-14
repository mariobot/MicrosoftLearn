using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Bebidas", Description = "Categoria de Bebidas"},
                new Category { CategoryId = 1, Name = "Panaderia", Description = "Categoria de Panaderia"},
                new Category { CategoryId = 1, Name = "Carnes", Description = "Categoria de Carnes"}
            };
        
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;        
        }
    }
}
