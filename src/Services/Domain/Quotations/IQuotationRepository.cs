namespace Andromeda.Domain.Quotations;

public interface IQuotationRepository
{
    Task<Quotation?> GetAsync(Guid id);
    void Add(Quotation quotation);
}