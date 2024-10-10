using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task<List<Inventory>> GetInventoriesByNameAsync(string name);

        Task<Inventory> GetInventoryByIdAsync(int inventoryId);

        Task AddInventoryAsync(Inventory inventory);

        Task DeleteInventoryAsync(int inventoryId);

        Task UpdateInventoryAsync(Inventory inventory);
    }
}
