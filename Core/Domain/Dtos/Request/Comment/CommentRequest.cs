using RAWAPI.Domain.Dtos.Response.Commend;

namespace RAWAPI.Domain.Dtos.Request.Commend {
    public class CommentRequest:CommandBase<CommandResult<CommentResponse>>{
        public string UserId { get; set; }
        public string ContentId { get; set; }
        public string Message { get; set; }
    }
}
