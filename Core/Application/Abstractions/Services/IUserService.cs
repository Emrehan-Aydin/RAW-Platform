using RAWAPI.Application.DTOs.User;
using RAWAPI.Domain.Dtos.Request.DashBoard;
using RAWAPI.Domain.Dtos.Response.User;
using RAWAPI.Domain.Entities.Identity;

namespace RAWAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
        Task<List<ListUser>> GetAllUsersAsync(int page, int size);
        int TotalUsersCount { get; }
        Task AssignRoleToUserAsnyc(string userId, string[] roles);
        Task<string[]> GetRolesToUserAsync(string userId);
        Task<UserDashboardDto> GetTopbarUserInfo(string userId);
        Task<string> GetUserProfilePhoto(string profileId);

        Task<GetTopTenResponse> GetTopTenUser();

    }
}
