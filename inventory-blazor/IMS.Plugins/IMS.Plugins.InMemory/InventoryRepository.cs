using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> inventories;

        public InventoryRepository()
        {
            inventories = new List<Inventory>()
            { 
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2 },
                new Inventory { InventoryId = 1, InventoryName = "Bike Body", Quantity = 10, Price = 15 },
                new Inventory { InventoryId = 1, InventoryName = "Bike Wheels", Quantity = 20, Price = 8 },
                new Inventory { InventoryId = 1, InventoryName = "Bike Pedels", Quantity = 20, Price = 1 }
            };
            
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return await Task.FromResult(inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase)));
            }
            else
            {   
                return inventories;
            }
        }
    }
}
