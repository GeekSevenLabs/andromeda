namespace Andromeda.Application.Shared.Products;

public class ProductCompositionValidator : AbstractValidator<ProductCompositionModel>
{
    public ProductCompositionValidator()
    {
        RuleFor(model => model.Description).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(model => model.Quantity).GreaterThan(0);
        RuleFor(model => model.RawMaterialId)
            .NotNull()
            .WithMessage("Matéria prima é obrigatória.")
            .Must((model, _) => model.RawMaterialIsDeleted == false)
            .WithMessage("Matéria prima indisponível.");
    }
}