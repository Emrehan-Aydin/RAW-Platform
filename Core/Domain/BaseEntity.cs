using RAWAPI.Domain.Interface;

namespace RAWAPI.Domain {
    public class BaseEntity : IBaseEntity {
        public Guid Id { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public bool RecordStatus { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }

        public void Created(string userid) {
            RecordStatus = false;
            CreatedDate = DateTimeOffset.UtcNow;
            CreatedBy = userid;
            Id = Guid.Empty;
        }

        public void Modified(string? userid = null) {
            ModifiedDate = DateTimeOffset.UtcNow;
            ModifiedBy = userid;
        }

        public void Deleted(string? userid = null) {
            RecordStatus = true;
            ModifiedDate = DateTimeOffset.UtcNow;
            ModifiedBy = userid;
        }
    }
}
