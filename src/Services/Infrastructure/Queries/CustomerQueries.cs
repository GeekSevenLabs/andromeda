using Andromeda.Application.Customers;
using Andromeda.Application.Shared.Customers.Get;
using Andromeda.Application.Shared.Customers.List;
using Andromeda.Infrastructure.Contexts;

namespace Andromeda.Infrastructure.Queries;

internal class CustomerQueries(AndromedaDbContext db) : ICustomerQueries
{
    public async Task<GetCustomerResponse?> GetAsync(Guid id)
    {
        return await db
            .Customers
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new GetCustomerResponse
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Contact.Email,
                Phone = c.Contact.Phone
            })
            .SingleOrDefaultAsync();
    }

    public async Task<ListCustomersResponseItem[]> ListAsync(string? term)
    {
        var query = db
            .Customers
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(term))
        {
            query = query.Where(c => c.Name.Contains(term));
        }

        return await query.Select(c => new ListCustomersResponseItem
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Contact.Email,
                Phone = c.Contact.Phone
            })
            .ToArrayAsync();
    }
}