using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext db;

        public InventoryRepository(IMSContext db)
        {
                this.db = db;
        }

        public Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            return null;
        }
    }
}
