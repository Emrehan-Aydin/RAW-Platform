using RAWAPI.Domain.Dtos.Request.Profile;

namespace RAWAPI.Domain.Dtos.Request.User {
    public class CreateUserRequest {
        public CreateUserCommandRequest CreateUserCommandRequest { get; set; }
        public CreateProfileRequest CreateProfileCommandRequest { get; set; }
    }
}
