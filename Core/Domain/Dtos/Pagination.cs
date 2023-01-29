using RAWAPI.Domain.Dtos.Response;

namespace RAWAPI.Domain.Dtos {
    public record Pagination<T>  {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public List<T> Content { get; set; } = new List<T>();
        public int TotalSize { get; set; } = 0;
        public bool StopPaging { get; set; } = false;
    }
}
