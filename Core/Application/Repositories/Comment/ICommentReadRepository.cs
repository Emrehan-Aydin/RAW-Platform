using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.Comment;
using RAWAPI.Domain.Dtos.Response.Comment;

namespace RAWAPI.Application.Repositories.Content {
    public interface ICommentReadRepository : IReadRepository<Domain.Entities.Comment.Comment> {
        Pagination<CommentListResponse> GetCommentList(CommentListRequest request);
    }
}
