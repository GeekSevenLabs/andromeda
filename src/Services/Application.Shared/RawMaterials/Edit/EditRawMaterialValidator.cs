namespace Andromeda.Application.Shared.RawMaterials.Edit;

public class EditRawMaterialValidator : AbstractValidator<EditRawMaterialRequest>
{
    public EditRawMaterialValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100)
            .WithName("Nome");
        
        RuleFor(request => request.Brand)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100)
            .WithName("Marca");
        
        RuleFor(request => request.Description)
            .MaximumLength(500)
            .WithName("Descrição"); 

        RuleFor(request => request.UnitOfMeasure)
            .NotEmpty()
            .IsInEnum()
            .WithName("Unidade de Medida");
        
        RuleFor(request => request.CostPerUnit)
            .NotEmpty()
            .PrecisionScale(18, 2, false)
            .GreaterThan(0)
            .WithName("Custo por unidade");
    }
}