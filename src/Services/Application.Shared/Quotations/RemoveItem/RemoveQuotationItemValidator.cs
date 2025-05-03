namespace Andromeda.Application.Shared.Quotations.RemoveItem;

public class RemoveQuotationItemValidator : AbstractValidator<RemoveQuotationItemRequest>
{
    public RemoveQuotationItemValidator()
    {
        RuleFor(request => request.Id).NotEmpty().WithName("Orçamento");
        RuleFor(request => request.ItemId).NotEmpty().WithName("Item do Orçamento");
    }
}