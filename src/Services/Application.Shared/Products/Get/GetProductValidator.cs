namespace Andromeda.Application.Shared.Products.Get;

public class GetProductValidator : AbstractValidator<GetProductRequest>
{
    public GetProductValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}