using Andromeda.Application.Shared.RawMaterials;
using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Application.Shared.RawMaterials.List;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public class DeiRawMaterialSelectorField : GslSearchSelectorAbstractField<RawMaterialDto, Guid>
{
    public DeiRawMaterialSelectorField()
    {
        Clearable = true;
        Label = "Matéria Prima";
        Placeholder = "Selecione uma matéria prima";
    }

    [Inject] public required IRawMaterialViewService ViewService { get; set; }

    protected override Func<string, Task<RawMaterialDto[]>> Search => SearchAsync;
    protected override Func<Guid, Task<RawMaterialDto>> Recover => RecoverAsync;
    protected override Func<RawMaterialDto, string> ToText => raw => raw.ToString();
    protected override Func<RawMaterialDto, Guid> ToValue => raw => raw.Id;

    private async Task<RawMaterialDto> RecoverAsync(Guid id)
    {
        return await ViewService.GetAsync(new GetRawMaterialRequest { Id = id });
    }

    private async Task<RawMaterialDto[]> SearchAsync(string term)
    {
        var request = new ListRawMaterialsRequest { Term = term };
        return await ViewService.ListAsync(request);
    }
}