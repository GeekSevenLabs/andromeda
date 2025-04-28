using Andromeda.Application.Shared.Quotations.Get;

namespace Andromeda.Application.Quotations.Get;

public class GetQuotationHandler(IQuotationQueries queries) : IHandler<GetQuotationRequest, GetQuotationResponse>
{
    public async Task<GetQuotationResponse> HandleAsync(GetQuotationRequest request, CancellationToken cancellationToken = default)
    {
        var response = await queries.GetAsync(request.Id);
        Throw.Http.NotFound.When.Null(response, "Orçamento não encontrado.");
        
        return response;
    }
}