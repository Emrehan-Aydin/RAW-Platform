namespace RAWAPI.Domain.Dtos.Request.User
{
    public class LoginRequestDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
