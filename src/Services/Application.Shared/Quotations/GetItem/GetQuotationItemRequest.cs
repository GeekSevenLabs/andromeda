namespace Andromeda.Application.Shared.Quotations.GetItem;

public class GetQuotationItemRequest : IRequest<GetQuotationItemResponse>
{
    public required Guid Id { get; init; }
}