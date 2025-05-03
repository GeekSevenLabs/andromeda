using Andromeda.Domain.Quotations;
using Andromeda.Infrastructure.Contexts;

namespace Andromeda.Infrastructure.Repositories;

internal class QuotationRepository(AndromedaDbContext db) : BaseRepository<Quotation, Guid>(db), IQuotationRepository;