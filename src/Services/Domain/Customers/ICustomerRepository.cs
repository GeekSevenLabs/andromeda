namespace Andromeda.Domain.Customers;

public interface ICustomerRepository
{
    void Add(Customer customer);
    void Remove(Customer customer);
    Task<Customer?> GetAsync(Guid id);
}