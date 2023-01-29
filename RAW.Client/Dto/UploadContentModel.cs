namespace RAW.Client.Dto {
    public class UploadContentModel : PageResponse{
        public string? Abstract { get; set; }
        public string? Link { get; set; }
        public string? Category { get; set; }
        public bool Anonymous { get; set; } = false;
    }
}
