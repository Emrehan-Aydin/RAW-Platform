namespace RAWAPI.Domain.Interface {
    public interface IBaseEntity {
        Guid Id { get; }
        DateTimeOffset CreatedDate { get; }
        DateTimeOffset? ModifiedDate { get; }
        string? CreatedBy { get; }
        string? ModifiedBy { get; }
        bool RecordStatus { get; }

        void Created(string userid);
        void Modified(string? userid);
        void Deleted(string? userid);
    }
}
