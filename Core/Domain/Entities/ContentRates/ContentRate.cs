namespace RAWAPI.Domain.Entities.ContentRates {
    public class ContentRate :BaseEntity{
        public string UserId { get; set; }
        public string ContentId { get; set; }
        public short Rate { get; set; }
    }
}
