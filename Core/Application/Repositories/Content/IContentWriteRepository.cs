
namespace RAWAPI.Application.Repositories.Content {
    public interface IContentWriteRepository : IWriteRepository<Domain.Entities.Contents.Content> {
        void ContentRefreshProcessor(string category);
    }
}
