using Andromeda.Domain.RawMaterials;
using Andromeda.Infrastructure.Contexts;

namespace Andromeda.Infrastructure.Repositories;

internal class RawMaterialRepository(AndromedaDbContext db) : 
    BaseRepository<RawMaterial, Guid>(db), 
    IRawMaterialRepository;