using IMS.CoreBusiness;

namespace IMS.UseCases
{
    public interface IViewInventoriesByNameUseCase
    {
        void CallRequestRefresh();
        Task<List<Inventory>> ExecuteAsync(string name = "");
    }
}