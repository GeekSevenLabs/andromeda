using Andromeda.Application.Shared.Quotations.Get;
using Andromeda.Application.Shared.Quotations.GetItem;
using Andromeda.Application.Shared.Quotations.List;

namespace Andromeda.Application.Quotations;

public interface IQuotationQueries
{
    Task<ListQuotationsResponseItem[]> ListAsync();
    Task<GetQuotationResponse?> GetAsync(Guid id);
    Task<GetQuotationItemResponse?> GetItemAsync(Guid id);
}