namespace RAWAPI.Domain.Dtos.Response.Content {
    public class GetOnlineContentResponse {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string ProfilePhoto { get; set; }
        public string UserFullName { get; set; }
        public string? Link { get; set; }
        public string? Abstract { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
