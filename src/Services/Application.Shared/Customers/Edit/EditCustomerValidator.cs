namespace Andromeda.Application.Shared.Customers.Edit;

public class EditCustomerValidator : AbstractValidator<EditCustomerRequest>
{
    public EditCustomerValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithName("Nome");
        RuleFor(request => request.Phone).NotEmpty().WithName("Celular");
        RuleFor(request => request.Email).NotEmpty().EmailAddress().WithName("E-mail");
    }
}