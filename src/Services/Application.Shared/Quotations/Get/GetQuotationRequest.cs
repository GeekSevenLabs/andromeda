namespace Andromeda.Application.Shared.Quotations.Get;

public class GetQuotationRequest : IRequest<GetQuotationResponse>
{
    public required Guid Id { get; set; }
}