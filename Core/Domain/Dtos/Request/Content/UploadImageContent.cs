using RAWAPI.Domain.Dtos.Response.Content;
using RAWAPI.Domain.Entities.File;

namespace RAWAPI.Domain.Dtos.Request.Content {
    public class UploadImageContent : CommandBase<CommandResult<UploadContentResponse>> {
        public string? UserId { get; set; }
        public string? Abstract { get; set; }
        public ImageFile? Content { get; set; }
        public bool? Anonymous { get; set; }
        public string? Category { get; set; }
    }
}