using RAWAPI.Domain.Entities.File;

namespace RAWAPI.Domain.ApiRequest {
    public class CreateProfileDto {
        public ImageFile profilePhoto { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
    }
}
