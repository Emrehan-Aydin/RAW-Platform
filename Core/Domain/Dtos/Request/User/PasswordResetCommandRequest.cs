using MediatR;
using RAWAPI.Domain.Dtos.Response.User;

namespace RAWAPI.Domain.Dtos.Request.User
{
    public class PasswordResetCommandRequest : IRequest<PasswordResetCommandResponse>
    {
        public string Email { get; set; }
    }
}