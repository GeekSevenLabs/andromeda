using Andromeda.Application.Shared.Customers.Get;

namespace Andromeda.Application.Shared.Customers.Edit;

public class EditCustomerRequest : IRequest
{
    public Guid? Id { get; set; }
    
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public void CopyFrom(GetCustomerResponse customer)
    {
        Id = customer.Id;
        Name = customer.Name;
        Phone = customer.Phone;
        Email = customer.Email;
    }
}