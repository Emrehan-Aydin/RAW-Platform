using RAWAPI.Application.Repositories.Content;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.ContentRate {
    public class ContentRateWriteRepository : WriteRepository<Domain.Entities.ContentRates.ContentRate> , IContentRateWriteRepository{
        private readonly RawDbContext _context;
        public ContentRateWriteRepository(RawDbContext context) : base(context) {
            _context = context;
        }
    }
}
