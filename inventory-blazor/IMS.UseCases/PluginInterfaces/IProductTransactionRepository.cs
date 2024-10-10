using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task<IEnumerable<ProductTransaction>> GetProductTransactionsAsync(
            string productName,
            DateTime? dateFrom,
            DateTime? dateTo,
            ProductTransactionType? transactionType);

        Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneBy);

        Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price, string doneBy);
    }
}
