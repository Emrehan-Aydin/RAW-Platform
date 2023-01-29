using RAWAPI.Application.Abstractions.Services;
using RAWAPI.Application.DTOs.User;
using RAWAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RAWAPI.Domain.Dtos.Request.User;
using RAWAPI.Domain.Dtos.Response.User;
using RAWAPI.Domain.Dtos.Response.Profile;
using RAWAPI.Application.Repositories.Profile;

namespace RAWAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly IProfileWriteRepository _profileService;
        public CreateUserCommandHandler(IUserService userService, IProfileWriteRepository profileService) {
            _userService = userService;
            _profileService = profileService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse userResponse = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.Username,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Username = request.Username,
            });

            return new()
            {
                UserId = userResponse.UserId,
                Message = userResponse.Message,
                Succeeded = userResponse.Succeeded,
            };

            //throw new UserCreateFailedException();
        }
    }
}
