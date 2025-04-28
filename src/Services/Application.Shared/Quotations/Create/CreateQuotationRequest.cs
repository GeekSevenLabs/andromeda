namespace Andromeda.Application.Shared.Quotations.Create;

public class CreateQuotationRequest : IRequest<CreateQuotationResponse>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public Guid? CustomerId { get; set; }
}