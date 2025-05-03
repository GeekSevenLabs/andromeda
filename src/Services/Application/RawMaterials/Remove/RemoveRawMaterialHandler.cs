using Andromeda.Application.Shared.RawMaterials.Remove;
using Andromeda.Domain;
using Andromeda.Domain.RawMaterials;

namespace Andromeda.Application.RawMaterials.Remove;

public class RemoveRawMaterialHandler(
    IRawMaterialRepository repository,
    IAndromedaUnitOfWork unitOfWork) : IHandler<RemoveRawMaterialRequest>
{
    public async Task HandleAsync(RemoveRawMaterialRequest request, CancellationToken cancellationToken = default)
    {
        var rawMaterial = await repository.GetAsync(request.Id);
        
        Throw.Http.NotFound.When.Null(rawMaterial, "Matéria prima não encontrada.");
        Throw.When.True(rawMaterial.IsDeleted, "Matéria prima já excluída.");
        
       rawMaterial.Delete();
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}