namespace RAWAPI.Domain.Entities.Message {
    public class Message : BaseEntity {
        public Guid Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId{ get; set; }
        public string Content{ get; set; }
        
    }
}
