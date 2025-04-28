using Andromeda.Application.Quotations;
using Andromeda.Application.Shared.Quotations.Get;
using Andromeda.Application.Shared.Quotations.GetItem;
using Andromeda.Application.Shared.Quotations.List;
using Andromeda.Infrastructure.Contexts;

namespace Andromeda.Infrastructure.Queries;

// TODO: podemos refatorar para usar Dapper para as queries de leitura

internal class QuotationQueries(AndromedaDbContext db) : IQuotationQueries
{
    public Task<ListQuotationsResponseItem[]> ListAsync()
    {
        var query = from quotation in db.Quotations
            join customer in db.Customers on quotation.CustomerId equals customer.Id
            select new ListQuotationsResponseItem
            {
                Id = quotation.Id,
                Title = quotation.Title,
                Description = quotation.Description,
                Price = quotation.Price,
                Status = quotation.Status,
                ValidUntil = quotation.ValidUntil,
                CustomerName = customer.Name,
                CustomerEmail = customer.Contact.Email
            };

        return query.ToArrayAsync();
    }

    public async Task<GetQuotationResponse?> GetAsync(Guid id)
    {
        var query = from quotation in db.Quotations
            join customer in db.Customers on quotation.CustomerId equals customer.Id
            where quotation.Id == id
            select new
            {
                quotation.Id,
                quotation.Title,
                quotation.Description,
                CustomerName = customer.Name,
                CustomerEmail = customer.Contact.Email,
                CustomerPhone = customer.Contact.Phone,
                Items = quotation.Items.Select(item => new
                {
                    item.Id,
                    item.ProductId,
                    item.Quantity,
                    item.Price,
                    item.PricePerUnit,
                    item.Description
                }).ToArray()
            };

        var result = await query.SingleOrDefaultAsync();

        if (result == null)
        {
            return null;
        }

        var productIds = result
            .Items
            .Select(i => i.ProductId)
            .Distinct()
            .ToArray();

        var productsDic = await db.Products
            .Where(p => productIds.Contains(p.Id))
            .ToDictionaryAsync(p => p.Id);

        return new GetQuotationResponse
        {
            Id = result.Id,
            Title = result.Title,
            Description = result.Description,
            CustomerName = result.CustomerName,
            CustomerEmail = result.CustomerEmail,
            CustomerPhone = result.CustomerPhone,
            Items = result.Items.Select(item => new GetQuotationResponseItem()
            {
                Id = item.Id,
                ProductName = productsDic[item.ProductId].Name,
                Quantity = item.Quantity,
                Price = item.Price,
                PricePerUnit = item.PricePerUnit,
                Description = item.Description
            }).ToArray()
        };

    }

    public Task<GetQuotationItemResponse?> GetItemAsync(Guid id)
    {
        var query = from item in db.QuotationItems
            where item.Id == id
            select new GetQuotationItemResponse
            {
                Id = item.QuotationId,
                ItemId = item.Id,
                ProductId = item.ProductId,
                Description = item.Description,
                Quantity = item.Quantity
            };

        return query.SingleOrDefaultAsync();
    }
}