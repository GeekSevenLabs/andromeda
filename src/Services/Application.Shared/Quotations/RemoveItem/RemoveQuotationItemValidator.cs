namespace Andromeda.Application.Shared.Quotations.RemoveItem;

public class RemoveQuotationItemValidator : AbstractValidator<RemoveQuotationItemRequest>
{
    public RemoveQuotationItemValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
        RuleFor(request => request.ItemId).NotEmpty();
    }
}