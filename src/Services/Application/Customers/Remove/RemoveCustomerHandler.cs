using Andromeda.Application.Shared.Customers.Remove;
using Andromeda.Domain;
using Andromeda.Domain.Customers;

namespace Andromeda.Application.Customers.Remove;

public class RemoveCustomerHandler(ICustomerRepository repository, IAndromedaUnitOfWork unitOfWork) : IHandler<RemoveCustomerRequest>
{
    public async Task HandleAsync(RemoveCustomerRequest request, CancellationToken cancellationToken = default)
    {
        var customer = await repository.GetAsync(request.Id);
        Throw.Http.NotFound.When.Null(customer, "Cliente não encontrado.");
        
        // TODO: válidar se o cliente tem orçamentos para ele
        
        repository.Remove(customer);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}