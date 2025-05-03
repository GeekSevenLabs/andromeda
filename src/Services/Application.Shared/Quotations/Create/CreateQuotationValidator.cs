namespace Andromeda.Application.Shared.Quotations.Create;

public class CreateQuotationValidator : AbstractValidator<CreateQuotationRequest>
{
    public CreateQuotationValidator()
    {
        RuleFor(request => request.Title).NotEmpty().MaximumLength(100).WithName("Título");
        RuleFor(request => request.Description).NotEmpty().MaximumLength(500).WithName("Descrição");
        RuleFor(request => request.CustomerId).NotNull().WithName("Cliente");
    }
}