using Andromeda.Application.Shared.Quotations.List;

namespace Andromeda.Application.Quotations.List;

public class ListQuotationsHandler(IQuotationQueries queries) : IHandler<ListQuotationsRequest, ListQuotationsResponseItem[]>
{
    public async Task<ListQuotationsResponseItem[]> HandleAsync(ListQuotationsRequest request, CancellationToken cancellationToken = default)
    {
        return await queries.ListAsync();

    }
}