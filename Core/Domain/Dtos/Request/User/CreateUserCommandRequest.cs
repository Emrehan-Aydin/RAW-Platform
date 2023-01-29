using MediatR;
using RAWAPI.Domain.Dtos.Response.User;

namespace RAWAPI.Domain.Dtos.Request.User {
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}