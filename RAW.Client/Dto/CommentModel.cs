namespace RAW.Client.Dto {
    public class CommentModel:PageResponse {
        public string Message { get; set; }
        public string ContentId { get; set; }
        public string UserId { get; set; }
    }
}
