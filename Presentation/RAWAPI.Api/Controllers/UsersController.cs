using RAWAPI.Application.Abstractions.Services;
using RAWAPI.Application.CustomAttributes;
using RAWAPI.Application.Enums;
using RAWAPI.Application.Features.Queries.AppUser.GetAllUsers;
using RAWAPI.Application.Features.Queries.AppUser.GetRolesToUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RAWAPI.Domain.Dtos.Request.User;
using RAWAPI.Domain.Dtos.Response.User;
using RAWAPI.Domain.Dtos;
using RAWAPI.Application.Abstractions.Storage;
using RAWAPI.Domain.Dtos.Response.Profile;
using RAWAPI.Domain.Dtos.Request;
using RAWAPI.Domain.Common;
using RAWAPI.Domain.ApiRequest;
using RAWAPI.Domain.Dtos.Request.Profile;

namespace RAWAPI.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IStorageService _storageService;
        public UsersController(IMediator mediator, IStorageService storageService) {
            _mediator = mediator;
            _storageService = storageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAccountRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(JSON.Map<CreateUserDto,CreateUserCommandRequest>(request.CreateUserCommandRequest));
            if (response != null) {
                CreateProfileRequest requestProfile = JSON.Map<CreateProfileDto, CreateProfileRequest>(request.CreateProfileCommandRequest);
                requestProfile.UserId = response.UserId;
                CreateProfileResponse profileresponse = await _mediator.Send(requestProfile);
            }
            return Ok(response);
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get All Users", Menu = "Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest getAllUsersQueryRequest)
        {
            GetAllUsersQueryResponse response = await _mediator.Send(getAllUsersQueryRequest);
            return Ok(response);
        }

        [HttpGet("get-roles-to-user/{UserId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles To Users", Menu = "Users")]
        public async Task<IActionResult> GetRolesToUser([FromRoute]GetRolesToUserQueryRequest getRolesToUserQueryRequest)
        {
            GetRolesToUserQueryResponse response = await _mediator.Send(getRolesToUserQueryRequest);
            return Ok(response);
        }

        [HttpPost("assign-role-to-user")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Assign Role To User", Menu = "Users")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommandRequest assignRoleToUserCommandRequest)
        {
            AssignRoleToUserCommandResponse response = await _mediator.Send(assignRoleToUserCommandRequest);
            return Ok(response);
        }

        [HttpGet("GetUserDashboardInfo/{UserId}")]
        public async Task<CommandResult<UserTopbarInfoResponse>> GetUserDashboardInfo([FromRoute] UserTopbarInfoRequest userTopbarInfoRequest) 
            => await _mediator.Send(userTopbarInfoRequest);

        [HttpGet("GetProfileDashboardInfo/{UserId}")]
        public async Task<CommandResult<GetUserProfileResponse>> GetProfileDashboardInfo([FromRoute] GetUserProfileRequest getUserProfileRequest)
            => await _mediator.Send(getUserProfileRequest);

        [HttpPost("UpdateProfile")]
        public async Task<CommandResult<UpdateProfileResponse>> UpdateProfile([FromBody] UpdateProfileRequest updateProfileDto)
            => await _mediator.Send(updateProfileDto);

        [HttpPost("GetTopTen")]
        public async Task<CommandResult<UpdateProfileResponse>> GetTopTen([FromBody] UpdateProfileRequest updateProfileDto)
           => await _mediator.Send(updateProfileDto);

    }
}
