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
        
        //TODO: Verificar se a matéria prima está sendo utilizada em algum produto.
        
        repository.Remove(rawMaterial);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}