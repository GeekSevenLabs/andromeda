using Andromeda.Application.Shared.Quotations.Create;
using Andromeda.Domain;
using Andromeda.Domain.Quotations;

namespace Andromeda.Application.Quotations.Create;

public class CreateQuotationHandler(IQuotationRepository repository, IAndromedaUnitOfWork unitOfWork) : IHandler<CreateQuotationRequest, CreateQuotationResponse>
{
    public async Task<CreateQuotationResponse> HandleAsync(CreateQuotationRequest request, CancellationToken cancellationToken = default)
    {
        var quotation = new Quotation(request.CustomerId.GetValueOrDefault(), request.Title, request.Description);
        repository.Add(quotation);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateQuotationResponse { Id = quotation.Id };
    }
}