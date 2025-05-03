using Andromeda.Application.Shared.Quotations.RemoveItem;
using Andromeda.Domain;
using Andromeda.Domain.Quotations;

namespace Andromeda.Application.Quotations.RemoveItem;

public class RemoveQuotationItemHandler(
    IQuotationRepository quotationRepository, 
    IAndromedaUnitOfWork unitOfWork) : IHandler<RemoveQuotationItemRequest>
{
    public async Task HandleAsync(RemoveQuotationItemRequest request, CancellationToken cancellationToken = default)
    {
        var quotation = await quotationRepository.GetAsync(request.Id);
        Throw.When.Null(quotation, "Orçamento não encontrada.");
        
        quotation.RemoveItem(request.ItemId);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}