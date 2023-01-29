using MediatR;
using RAWAPI.Domain.Dtos.Response.User;

namespace RAWAPI.Domain.Dtos.Request.User
{
    public class VerifyResetTokenCommandRequest : IRequest<VerifyResetTokenCommandResponse>
    {
        public string ResetToken { get; set; }
        public string UserId { get; set; }
    }
}