using Andromeda.Application.Shared.RawMaterials.Edit;
using Andromeda.Domain;
using Andromeda.Domain.RawMaterials;

namespace Andromeda.Application.RawMaterials.Edit;

public class EditRawMaterialHandler(
    IRawMaterialRepository repository,
    IAndromedaUnitOfWork unitOfWork) : IHandler<EditRawMaterialRequest>
{
    public async Task HandleAsync(EditRawMaterialRequest request, CancellationToken cancellationToken = default)
    {
        RawMaterial? rawMaterial;

        if (request.Id is null)
        {
            rawMaterial = new RawMaterial(
                request.Name,
                request.Brand,
                request.Description,
                request.UnitOfMeasure.GetValueOrDefault(), 
                request.CostPerUnit.GetValueOrDefault());
            
            repository.Add(rawMaterial);
        }
        else
        {
            rawMaterial = await repository.GetAsync(request.Id.Value);
            Throw.Http.NotFound.When.Null(rawMaterial, "Matéria-prima não encontrada.");
            
            rawMaterial.Update(
                request.Name,
                request.Brand,
                request.Description,
                request.UnitOfMeasure.GetValueOrDefault(), 
                request.CostPerUnit.GetValueOrDefault());
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}