namespace RAWAPI.Domain.Entities.Comment {
    public class Comment : BaseEntity {
        public string UserId { get; set; }
        public string ContentId { get; set; }
        public string Message { get; set; }
    }
}
