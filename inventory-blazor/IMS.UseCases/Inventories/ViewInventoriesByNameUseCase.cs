using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
{
    private readonly IInventoryRepository inventoryRepository;

    public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
    {
        this.inventoryRepository = inventoryRepository;
    }

    public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
    {
        return await inventoryRepository.GetInventoriesByNameAsync(name);
    }
}
