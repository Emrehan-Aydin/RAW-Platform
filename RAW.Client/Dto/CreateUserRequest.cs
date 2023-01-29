using RAWAPI.Domain.ApiRequest;

namespace RAW.Client.Dto {
    public class CreateUserRequest {
        public CreateUserDto CreateUserCommandRequest { get; set; }
        public CreateProfileDto CreateProfileCommandRequest { get; set; }
    }
}
