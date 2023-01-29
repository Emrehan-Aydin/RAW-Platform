using RAWAPI.Domain.Entities.File;

namespace RAWAPI.Domain.ApiRequest.Content {
    public class UploadContentDto {
        public string? UserId { get; set; }
        public string? Abstract { get; set; }
        public string? ContentLink { get; set; }
        public ImageFile? Content { get; set; }
        public bool? Anonymous { get; set; }
        public string? Category { get; set; }
    }
}
