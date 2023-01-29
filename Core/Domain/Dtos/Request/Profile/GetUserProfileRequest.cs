using MediatR;
using RAWAPI.Domain.Dtos.Response.Profile;

namespace RAWAPI.Domain.Dtos.Request.Profile {
    public class GetUserProfileRequest : CommandBase<CommandResult<GetUserProfileResponse>> {
        public string UserId { get; set; }
    }
}
