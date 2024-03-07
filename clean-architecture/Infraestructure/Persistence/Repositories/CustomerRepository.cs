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

    public async Task<Customer?> GetByIdAsync(CustomerId id) => await this.context.Customers.SingleOrDefaultAsync(c => c.Id == id);
}
