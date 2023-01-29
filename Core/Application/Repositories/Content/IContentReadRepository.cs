
using RAWAPI.Domain.Dtos.Response.Content;

namespace RAWAPI.Application.Repositories.Content {
    public interface IContentReadRepository : IReadRepository<Domain.Entities.Contents.Content> {
        GetOnlineContentResponse GetOnlineContent(string category);
    }
}
