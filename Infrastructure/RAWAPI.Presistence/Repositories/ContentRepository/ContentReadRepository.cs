using Microsoft.Extensions.Configuration;
using RAWAPI.Application.Repositories.Content;
using RAWAPI.Domain.Dtos.Response.Content;
using RAWAPI.Domain.Entities.Contents;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.ContentRepository {
    public class ContentReadRepository : ReadRepository<Content>, IContentReadRepository {
        private readonly RawDbContext _context;
        private readonly IConfiguration _configuration;
        public ContentReadRepository(RawDbContext context, IConfiguration configuration) : base(context) {
            _context = context;
            _configuration = configuration;
        }

        public GetOnlineContentResponse GetOnlineContent(string category) {
            var result = _context.Content.Where(c => c.IsOnline && c.ContentCategory == category).Select(entity =>
            new GetOnlineContentResponse {
                UserId = entity.IsAnoAnonymousny ? "Anonymousny" : entity.UserId,
                Id = entity.Id.ToString(),
                Link = entity.Context,
                Abstract = entity.ContentAbstract,
                CreatedDate = entity.CreatedDate
            }).FirstOrDefault();
            if(result != null) {
                result.Link = category == "Draw" ?
                    $"{_configuration["BaseStorageUrl"]}/content-images/{result.Link}" :
                    result.Link;

                return result;
            }
            else {
                throw new ArgumentNullException("İçerik Bulunamadı!");
            }
        }
    }
}
