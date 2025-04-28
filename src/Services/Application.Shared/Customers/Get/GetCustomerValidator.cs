namespace Andromeda.Application.Shared.Customers.Get;

public class GetCustomerValidator : AbstractValidator<GetCustomerRequest>
{
    public GetCustomerValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}