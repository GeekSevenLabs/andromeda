using Andromeda.Application.Shared.Quotations.Create;
using Andromeda.Application.Shared.Quotations.EditeItem;
using Andromeda.Application.Shared.Quotations.Get;
using Andromeda.Application.Shared.Quotations.GetItem;
using Andromeda.Application.Shared.Quotations.List;
using Andromeda.Application.Shared.Quotations.RemoveItem;

namespace Andromeda.Application.Shared.Quotations;

public interface IQuotationViewService
{
    Task<CreateQuotationResponse> CreateAsync(CreateQuotationRequest request);
    Task EditItemAsync(EditQuotationItemRequest request);
    Task<GetQuotationResponse> GetAsync(GetQuotationRequest request);
    Task<GetQuotationItemResponse> GetItemAsync(GetQuotationItemRequest request);
    Task<ListQuotationsResponseItem[]> ListAsync(ListQuotationsRequest request);
    Task RemoveItemAsync(RemoveQuotationItemRequest request);
}