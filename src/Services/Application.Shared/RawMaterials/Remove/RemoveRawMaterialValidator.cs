namespace Andromeda.Application.Shared.RawMaterials.Remove;

public class RemoveRawMaterialValidator : AbstractValidator<RemoveRawMaterialRequest>
{
    public RemoveRawMaterialValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}