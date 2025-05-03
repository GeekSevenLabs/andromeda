namespace Andromeda.Application.Shared.Quotations.GetItem;

public class GetQuotationItemValidator : AbstractValidator<GetQuotationItemRequest>
{
    public GetQuotationItemValidator()
    {
        RuleFor(request => request.Id).NotEmpty().WithName("Item do Orçamento");
    }
}