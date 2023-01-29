using RAWAPI.Domain.Dtos.Response.Comment;

namespace RAWAPI.Domain.Dtos.Request.Comment {
    public class CommentListRequest : CommandBase<CommandResult<Pagination<CommentListResponse>>> {
        public int Page { get; set; }
        public int Size { get; set; }
        public string ContentId { get; set; }
    }
}
