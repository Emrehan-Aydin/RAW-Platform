namespace RAW.Client.Dto {
    public class Pagination<T> : PageResponse {
        public string ContentId { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public int TotalSize { get; set; } = 0;
        public List<T> Content { get; set; } = new List<T>();
        public bool StopPaging { get; set; } = false;
    }
}
