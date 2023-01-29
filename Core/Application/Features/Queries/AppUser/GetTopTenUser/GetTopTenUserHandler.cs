using MediatR;
using RAWAPI.Application.Abstractions.Services;
using RAWAPI.Domain.Dtos;
using RAWAPI.Domain.Dtos.Request.User;
using RAWAPI.Domain.Dtos.Response.User;

public class GetTopTenUserHandler : IRequestHandler<GetTopTenRequest, CommandResult<GetTopTenResponse>> {
    readonly IUserService _userService;

    public GetTopTenUserHandler(IUserService userService) {
        _userService = userService;
    }


    public Task<CommandResult<GetTopTenResponse>> Handle(GetTopTenRequest request, CancellationToken cancellationToken) {
        return null;
    }
}