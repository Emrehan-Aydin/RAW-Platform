using RAWAPI.Application.Repositories.Content;
using RAWAPI.Presistence.Context;

namespace RAWAPI.Presistence.Repositories.ContentRate {
    public class CommentWriteRepository : WriteRepository<Domain.Entities.Comment.Comment> , ICommentWriteRepository {
        private readonly RawDbContext _context;
        public CommentWriteRepository(RawDbContext context) : base(context) {
            _context = context;
        }
    }
}
