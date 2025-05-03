using Andromeda.Application.Shared.Customers.Edit;
using Andromeda.Domain;
using Andromeda.Domain.Customers;

namespace Andromeda.Application.Customers.Edit;

public class EditCustomerHandler(
    ICustomerRepository repository, 
    IAndromedaUnitOfWork unitOfWork) : IHandler<EditCustomerRequest>
{
    public async Task HandleAsync(EditCustomerRequest request, CancellationToken cancellationToken = default)
    {
        Customer customer;
        var contact = new ContactVo(request.Phone!, request.Email!);
        
        if (request.Id.HasValue)
        {
            var customerFound = await repository.GetAsync(request.Id.Value);
            Throw.Http.NotFound.When.Null(customerFound, "Cliente não encontrado.");
            customer = customerFound;
            customer.Update(request.Name!, contact);
        }
        else
        {
            customer = new Customer(request.Name!, contact);
            repository.Add(customer);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}