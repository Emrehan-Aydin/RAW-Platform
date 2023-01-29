namespace RAWAPI.Domain.Entities.Contents {
    public class Content:BaseEntity {
        public string UserId { get; set; } = string.Empty;
        public string? ContentAbstract { get; set; } = string.Empty;
        public string? Context { get; set; } = string.Empty;
        public string ContentCategory { get; set; } = string.Empty;
        public bool IsAnoAnonymousny { get; set; } = false;
        public bool IsShowed { get; set; } = false;
        public bool IsOnline { get; set; } = false;
    }
}
