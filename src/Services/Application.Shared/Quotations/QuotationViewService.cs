using Andromeda.Application.Shared.Quotations.Create;
using Andromeda.Application.Shared.Quotations.EditeItem;
using Andromeda.Application.Shared.Quotations.Get;
using Andromeda.Application.Shared.Quotations.GetItem;
using Andromeda.Application.Shared.Quotations.List;
using Andromeda.Application.Shared.Quotations.RemoveItem;

namespace Andromeda.Application.Shared.Quotations;

public class QuotationViewService(IEndpointService endpointService) : IQuotationViewService
{
    public async Task<CreateQuotationResponse> CreateAsync(CreateQuotationRequest request)
    {
        return await endpointService.PostAsync(AndromedaHandlerDefinitions.Quotations.CreateQuotation, request);
    }

    public async Task EditItemAsync(EditQuotationItemRequest request)
    {
        await endpointService.PostAsync(AndromedaHandlerDefinitions.Quotations.EditQuotationItem, request);
    }

    public async Task<GetQuotationResponse> GetAsync(GetQuotationRequest request)
    {
        return await endpointService.GetAsync(AndromedaHandlerDefinitions.Quotations.GetQuotation, request);
    }

    public async Task<GetQuotationItemResponse> GetItemAsync(GetQuotationItemRequest request)
    {
        return await endpointService.GetAsync(AndromedaHandlerDefinitions.Quotations.GetQuotationItem, request);
    }

    public async Task<ListQuotationsResponseItem[]> ListAsync(ListQuotationsRequest request)
    {
        return await endpointService.GetAsync(AndromedaHandlerDefinitions.Quotations.ListQuotations, request);
    }

    public async Task RemoveItemAsync(RemoveQuotationItemRequest request)
    {
        await endpointService.PostAsync(AndromedaHandlerDefinitions.Quotations.RemoveQuotationItem, request);
    }
}