namespace RAWAPI.Domain.Entities.File {
    public class ImageFile {
        public byte[]? FileBytes { get; set; }
        public string? FileName { get; set; } = "0000";
        public string? FileExtension { get; set; }
    }
}
