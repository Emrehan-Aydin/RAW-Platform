using Newtonsoft.Json;
using RAWAPI.Domain.Entities.File;

namespace RAWAPI.Domain.Entities.Profile {
    public class Profile : BaseEntity{
        public string UserId { get; set; }
        [JsonProperty("ProfilePhotoUrl")]
        public string? ProfilePhotoId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Abstract { get; set; }
    }
}
