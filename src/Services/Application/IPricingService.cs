namespace Andromeda.Application;

public interface IPricingService
{
    Task<decimal> CalculatePriceAsync(Guid productId, int quantity);
}