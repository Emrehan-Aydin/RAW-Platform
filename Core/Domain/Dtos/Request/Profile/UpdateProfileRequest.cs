using RAWAPI.Domain.Dtos.Response.Profile;
using RAWAPI.Domain.Entities.File;

namespace RAWAPI.Domain.Dtos.Request.Profile {
    public class UpdateProfileRequest : CommandBase<CommandResult<UpdateProfileResponse>> {
        public ImageFile? profilePhoto { get; set; }
        public string? UserId { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Abstract { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; } = DateTime.Now;
    }
}
