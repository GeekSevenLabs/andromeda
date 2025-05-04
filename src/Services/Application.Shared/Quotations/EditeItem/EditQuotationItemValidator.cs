namespace Andromeda.Application.Shared.Quotations.EditeItem;

public class EditQuotationItemValidator : AbstractValidator<EditQuotationItemRequest>
{
    public EditQuotationItemValidator()
    {
        RuleFor(request => request.Id).NotEmpty().WithName("Composição");
        
        RuleFor(request => request.Quantity).NotEmpty().GreaterThan(0).WithName("Quantidade");
        RuleFor(request => request.ProductId).NotEmpty().WithName("Produto");
        RuleFor(request => request.Description).NotEmpty().MaximumLength(500).WithName("Descrição");
    }
}