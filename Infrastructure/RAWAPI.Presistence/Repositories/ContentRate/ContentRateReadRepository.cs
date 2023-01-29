using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using RAWAPI.Application.Repositories.ContentRate;
using RAWAPI.Domain.Dtos.Response.Comment;
using RAWAPI.Domain.Dtos.Response.User;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.ContentRate {
    public class ContentRateReadRepository : ReadRepository<Domain.Entities.ContentRates.ContentRate>, IContentRateReadRepository {
        private RawDbContext _context;
        private readonly IConfiguration _configuration;
        public ContentRateReadRepository(RawDbContext context, IConfiguration configuration) : base(context) {
            _context = context;
            _configuration = configuration;
        }

        //public GetTopTenResponse GetTopTenUser() {
        //    var result = _context.ContentRate.GroupBy(x => x.ContentId, (key, g) => new {
        //        ContentId = key,
        //        Rate = g.ToList()
        //    });

        //}
    }
}
