

namespace Andromeda.Domain.Quotations;

public class Quotation : Entity, IAggregateRoot
{
    private readonly List<QuotationItem> _items = [];

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Quotation() { } // Parameterless constructor for EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    
    public Quotation(Guid customerId, string title, string description)
    {
        CustomerId = customerId;
        Title = title;
        Description = description;
        Status = QuotationStatus.Draft;
        Price = 0;
        ValidUntil = null;
    }
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    
    public QuotationStatus Status { get; private set; }
    
    public decimal Price { get; private set; }
    public DateTimeOffset? ValidUntil { get; private set; }
    
    public Guid CustomerId { get; private set; }
    
    public IReadOnlyCollection<QuotationItem> Items => _items.AsReadOnly();
    
    public void Send()
    {
        Throw.When.NotEqual(Status, QuotationStatus.Draft, "Cotação não está em rascunho.");
        
        Status = QuotationStatus.Sent;
    }
    
    public void Approve(decimal price, DateTimeOffset validUntil)
    {
        Throw.When.NotEqual(Status, QuotationStatus.Sent, "Cotação ainda não foi enviada.");
        
        Status = QuotationStatus.Approve;
        Price = price;
        ValidUntil = validUntil;
    }
    
    public void Reject()
    {
        Throw.When.NotEqual(Status, QuotationStatus.Sent, "Cotação ainda não foi enviada.");
        Status = QuotationStatus.Rejected;
    }
    
    public void Cancel()
    {
        Throw.When.NotEqual(Status, QuotationStatus.Approve, "Cotação ainda não foi aprovada.");
        Status = QuotationStatus.Canceled;
    }
    
    public bool IsExpired() => ValidUntil.HasValue && ValidUntil.Value < DateTimeOffset.UtcNow;

    #region Items

    public void AddItem(Guid productId, int quantity, decimal price, string description)
    {
        Throw.When.NotEqual(Status, QuotationStatus.Draft, "Este Orçamento não permite remoção de itens.");
        
        _items.Add(new QuotationItem(Id, productId, quantity, price, description));
        Price = _items.Sum(item => item.Price);
    }
    
    public void UpdateItem(Guid itemId, int quantity, decimal price, string description)
    {
        Throw.When.NotEqual(Status, QuotationStatus.Draft, "Este Orçamento não permite remoção de itens.");
        
        var quotationItem = _items.FirstOrDefault(item => item.Id == itemId);
        Throw.When.Null(quotationItem, "Item não encontrado.");
        
        quotationItem.ChangePricing(quantity, price);
        quotationItem.ChangeDescription(description);
        
        Price = _items.Sum(item => item.Price);
    }
    
    public void RemoveItem(Guid itemId)
    {
        Throw.When.NotEqual(Status, QuotationStatus.Draft, "Este Orçamento não permite remoção de itens.");
        
        var quotationItem = _items.FirstOrDefault(item => item.Id == itemId);
        Throw.When.Null(quotationItem, "Item não encontrado.");
        
        _items.Remove(quotationItem);
        Price = _items.Sum(item => item.Price);
    }

    #endregion
}