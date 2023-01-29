using RAW.Client.Dto;

namespace RAW.Client.ViewModels {
    public class ContentViewModel :PageResponse{
        public string UserId { get; set; }
        public short UserRate { get; set; }
        public string Id { get; set; }
        public string ProfilePhoto { get; set; }
        public string UserFullName { get; set; }
        public string? Link { get; set; }
        public string? Abstract { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
