namespace RAWAPI.Domain.ApiRequest {
    public class CreateAccountRequest {
        public CreateUserDto CreateUserCommandRequest { get; set; }
        public CreateProfileDto CreateProfileCommandRequest { get; set; }
    }
}
