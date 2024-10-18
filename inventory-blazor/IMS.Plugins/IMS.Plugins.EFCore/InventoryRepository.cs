using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace IMS.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext db;

        public InventoryRepository(IMSContext db)
        {
            this.db = db;
        }

        public async Task<List<Inventory>> GetInventoriesByNameAsync(string name)
        {   
            var list = await db.Inventories.Where(x => x.InventoryName.ToLower().IndexOf(name.ToLower()) >= 0 ||
                                                    string.IsNullOrWhiteSpace(name) &&
                                                    x.IsActive == true).ToListAsync();

            return list;
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            return await db.Inventories.FindAsync(inventoryId);        
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            //To prevent same name
            if (db.Inventories.Any(x => x.InventoryName.ToLower() == inventory.InventoryName.ToLower()))
                return;

            this.db.Inventories.Add(inventory);
            await db.SaveChangesAsync();
        }

        public async Task DeleteInventoryAsync(int inventoryId)
        {
            var inventory = await db.Inventories.FindAsync(inventoryId);

            if (inventory != null)
            {
                db.Remove(inventory);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            if (db.Inventories.Any(x => x.InventoryId != inventory.InventoryId && x.InventoryName.ToLower() == inventory.InventoryName.ToLower())) 
                return;

            var inv = await this.db.Inventories.FindAsync(inventory.InventoryId);

            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;

                await db.SaveChangesAsync();
            }
        }
    }
}
