namespace Andromeda.Application.Shared.Products.Edit;

public class EditProductValidator : AbstractValidator<EditProductRequest>
{
    public EditProductValidator()
    {
        RuleFor(request => request.Name).NotEmpty().MinimumLength(3).MaximumLength(100).WithName("Nome");
        RuleFor(request => request.Description).NotEmpty().MinimumLength(10).MaximumLength(500).WithName("Descrição");

        RuleFor(request => request.Compositions)
            .NotEmpty()
            .WithMessage("Deve ser informado ao menos uma composição.");
        
        RuleForEach(request => request.Compositions).SetValidator(new ProductCompositionValidator());
    }
}