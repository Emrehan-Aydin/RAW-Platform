namespace RAW.Client.Dto {
    public class PaginationRequest {
        public string ContentId { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
