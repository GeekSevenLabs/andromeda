using Andromeda.Application.Shared.Quotations.GetItem;

namespace Andromeda.Application.Quotations.GetItem;

public class GetQuotationItemHandler(IQuotationQueries queries) : IHandler<GetQuotationItemRequest, GetQuotationItemResponse>
{
    public async Task<GetQuotationItemResponse> HandleAsync(GetQuotationItemRequest request, CancellationToken cancellationToken = default)
    {
        var quotationItem = await queries.GetItemAsync(request.Id);
        Throw.When.Null(quotationItem, "Item de orçamento não encontrado.");
        
        return quotationItem;
    }
}