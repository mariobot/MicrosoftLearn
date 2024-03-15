namespace Domain.Customers;

public interface ICustomerRepository
{
    Task Add(Customer customer);

    void Delete(Customer customer);

    void Update(Customer customer);

    Task<bool> ExistAsync (CustomerId id);

    Task<Customer?> GetByIdAsync(CustomerId id);

    Task<List<Customer>> GetAllAsync();
}