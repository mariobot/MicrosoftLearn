using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infraestucture.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext context;

    public CustomerRepository(ApplicationDbContext context)
    {
        this.context = context ?? throw new ArgumentException(nameof(context));
    }

    public async Task Add(Customer customer) => await this.context.Customers.AddAsync(customer);    

    public void Delete(Customer customer) => this.context.Customers.Remove(customer);

    public void Update(Customer customer) => this.context.Customers.Update(customer);

    public async Task<Customer?> GetByIdAsync(CustomerId id) => await this.context.Customers.SingleOrDefaultAsync(c => c.Id == id);

    public async Task<bool> ExistAsync(CustomerId id) => await this.context.Customers.AnyAsync(c => c.Id == id);
    
    public async Task<List<Customer>> GetAllAsync() => await this.context.Customers.ToListAsync();
}
