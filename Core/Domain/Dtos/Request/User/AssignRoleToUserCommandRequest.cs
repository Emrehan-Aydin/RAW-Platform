using MediatR;
using RAWAPI.Domain.Dtos.Response.User;

namespace RAWAPI.Domain.Dtos.Request.User
{
    public class AssignRoleToUserCommandRequest : IRequest<AssignRoleToUserCommandResponse>
    {
        public string UserId { get; set; }
        public string[] Roles { get; set; }
    }
}