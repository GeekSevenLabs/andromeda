namespace Andromeda.Application.Shared.Customers.Remove;

public class RemoveCustomerValidator : AbstractValidator<RemoveCustomerRequest>
{
    public RemoveCustomerValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}