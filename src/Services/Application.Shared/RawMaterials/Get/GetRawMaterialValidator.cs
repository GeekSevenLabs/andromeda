namespace Andromeda.Application.Shared.RawMaterials.Get;

public class GetRawMaterialValidator : AbstractValidator<GetRawMaterialRequest>
{
    public GetRawMaterialValidator()
    {
        RuleFor(request => request.Id).NotEmpty().WithName("Matéria-prima");
    }
}