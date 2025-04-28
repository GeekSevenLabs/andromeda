using Andromeda.Domain.Customers;
using Andromeda.Infrastructure.Contexts;

namespace Andromeda.Infrastructure.Repositories;

internal class CustomerRepository(AndromedaDbContext db) : BaseRepository<Customer, Guid>(db), ICustomerRepository;