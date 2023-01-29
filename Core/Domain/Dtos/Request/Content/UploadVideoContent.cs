using RAWAPI.Domain.Dtos.Response.Content;

namespace RAWAPI.Domain.Dtos.Request.Content {
    public class UploadVideoContent : CommandBase<CommandResult<UploadContentResponse>> {
        public string? UserId { get; set; }
        public string? ContentLink { get; set; }
        public string? Abstract { get; set; }
        public bool Anonymous { get; set; }
        public string? Category { get; set; }
    }
}