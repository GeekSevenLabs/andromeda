using Andromeda.Application.Shared.Quotations.EditeItem;
using Andromeda.Domain;
using Andromeda.Domain.Quotations;

namespace Andromeda.Application.Quotations.EditeItem;

public class EditQuotationItemHandler(
    IQuotationRepository quotationRepository,
    IPricingService pricingService,
    IAndromedaUnitOfWork unitOfWork) : IHandler<EditQuotationItemRequest>
{
    public async Task HandleAsync(EditQuotationItemRequest request, CancellationToken cancellationToken = default)
    {
        var quotation = await quotationRepository.GetAsync(request.Id);
        Throw.When.Null(quotation, "Orçamento não encontrada.");

        var productId = request.ProductId.GetValueOrDefault();
        
        var productPrice = await pricingService.CalculatePriceAsync(productId, request.Quantity);

        if (request.ItemId.HasValue)
        {
            quotation.UpdateItem(request.ItemId.Value, request.Quantity, productPrice, request.Description);
        }
        else
        {
            quotation.AddItem(productId, request.Quantity, productPrice, request.Description);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}