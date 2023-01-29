using MediatR;
using RAWAPI.Application.Abstractions.Services;
using RAWAPI.Domain.Dtos.Request.User;
using RAWAPI.Domain.Dtos.Response.User;
using Newtonsoft.Json;
using RAWAPI.Domain.Dtos;

namespace RAWAPI.Application.Features.Queries.TopbarInfo
{
    public class GetTopbarInfoCommandHandler : IRequestHandler<UserTopbarInfoRequest, CommandResult<UserTopbarInfoResponse>>
    {
        readonly IUserService _userService;
        public GetTopbarInfoCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CommandResult<UserTopbarInfoResponse>> Handle(UserTopbarInfoRequest request, CancellationToken cancellationToken)
        {

            var result = await _userService.GetTopbarUserInfo(request.UserId);


            return result is not null
                ? CommandResult<UserTopbarInfoResponse>.GetSucceed(JsonConvert.DeserializeObject<UserTopbarInfoResponse>(JsonConvert.SerializeObject(result)))
                : CommandResult<UserTopbarInfoResponse>.GetFailed("Kullanıcı Bulunamadı!");
        }
    }
}
