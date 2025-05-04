namespace Andromeda.Application.Shared.Quotations.Get;

public class GetQuotationValidator : AbstractValidator<GetQuotationRequest>
{
    public GetQuotationValidator()
    {
        RuleFor(request => request.Id).NotEmpty().WithName("Orçamento");
    }
}