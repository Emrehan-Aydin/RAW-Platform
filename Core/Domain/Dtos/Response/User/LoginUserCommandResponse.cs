namespace RAWAPI.Domain.Dtos.Response.User {
    public class LoginUserCommandResponse
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public Token Token { get; set; }
    }
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
    }
    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
    }
}
