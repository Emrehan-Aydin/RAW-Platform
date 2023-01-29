namespace RAWAPI.Application.RequestParameters {
    public record Pagination {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 10;
        public int TotalComment { get; set; }
    }
}
