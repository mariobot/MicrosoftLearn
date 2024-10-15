using IMS.CoreBusiness;

namespace IMS.UseCases
{
    public interface IViewInventoriesByNameUseCase
    {
        Task<List<Inventory>> ExecuteAsync(string name = "");
    }
}