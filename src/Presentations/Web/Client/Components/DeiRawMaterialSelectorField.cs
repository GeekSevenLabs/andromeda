using Andromeda.Application.Shared.RawMaterials;
using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Application.Shared.RawMaterials.List;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public class DeiRawMaterialSelectorField : DeiSelectorAbstractField<Guid>
{
    public DeiRawMaterialSelectorField()
    {
        Clearable = true;
        Label = "Matéria Prima";
        Placeholder = "Selecione uma matéria prima";
    }

    [Inject] public required IRawMaterialViewService ViewService { get; set; }

    protected override Func<string, Task<ChoiceOption<Guid>[]>> ItemsSearch => SearchAsync;
    protected override Func<Guid, Task<ChoiceOption<Guid>>> ItemRecover => RecoverAsync;

    private async Task<ChoiceOption<Guid>> RecoverAsync(Guid id)
    {
        var rawMaterial = await ViewService.GetAsync(new GetRawMaterialRequest { Id = id });
        return new ChoiceOption<Guid>(id, rawMaterial.Name);
    }

    private async Task<ChoiceOption<Guid>[]> SearchAsync(string term)
    {
        var request = new ListRawMaterialsRequest { Term = term };
        var rawMaterials = await ViewService.ListAsync(request);

        return rawMaterials
            .Select(rm => new ChoiceOption<Guid>(rm.Id, rm.Name))
            .ToArray();
    }
}