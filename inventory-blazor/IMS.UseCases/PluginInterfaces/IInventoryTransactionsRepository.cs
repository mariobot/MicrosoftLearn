using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryTransactionsRepository
    {
        Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionsAsync(
            string inventoryName,
            DateTime? dateFrom,
            DateTime? dateTo,
            InventoryTransactionType? transactionType);

        Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double price, string doneBy);
    }
}
