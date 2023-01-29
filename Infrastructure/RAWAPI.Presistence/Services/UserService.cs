using RAWAPI.Application.Abstractions.Services;
using RAWAPI.Application.DTOs.User;
using RAWAPI.Application.Exceptions;
using RAWAPI.Application.Helpers;
using RAWAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RAWAPI.Domain.Dtos.Request.DashBoard;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using RAWAPI.Application.Repositories.Profile;
using RAWAPI.Domain.Dtos.Response.User;
using RAWAPI.Application.Repositories.ContentRate;

namespace RAWAPI.Presistence.Services {
    public class UserService : IUserService {
        readonly UserManager<AppUser> _userManager;
        readonly IConfiguration _configuration;
        readonly IProfileReadRepository _profileReadService;
        readonly IContentRateReadRepository _contentRateReadService;

        public UserService(UserManager<AppUser> userManager, IProfileReadRepository profileReadService, IConfiguration configuration, IContentRateReadRepository contentRateReadService) {
            _userManager = userManager;
            _profileReadService = profileReadService;
            _configuration = configuration;
            _contentRateReadService = contentRateReadService;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model) {
            AppUser user = new AppUser {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                NameSurname = model.NameSurname,
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded, UserId = user.Id };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }
        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate) {
            if (user != null) {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();
        }
        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword) {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new PasswordChangeFailedException();
            }
        }

        public async Task<List<ListUser>> GetAllUsersAsync(int page, int size) {
            var users = await _userManager.Users
                  .Skip(page * size)
                  .Take(size)
                  .ToListAsync();

            return users.Select(user => new ListUser {
                Id = user.Id,
                Email = user.Email,
                NameSurname = user.NameSurname,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName

            }).ToList();
        }

        public int TotalUsersCount => _userManager.Users.Count();

        public async Task AssignRoleToUserAsnyc(string userId, string[] roles) {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                await _userManager.AddToRolesAsync(user, roles);
            }
        }
        public async Task<string[]> GetRolesToUserAsync(string userId) {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public async Task<UserDashboardDto> GetTopbarUserInfo(string userId) {
            AppUser user = await _userManager.FindByIdAsync(userId);
            string containerName = "profile-images";
            Domain.Entities.Profile.Profile profile = await _profileReadService.GetSingleAsync(x => x.UserId == userId);
            string photoPath = $"{_configuration["BaseStorageUrl"]}/{containerName}/{profile.ProfilePhotoId}";
            if (user != null) {
                return new() {
                    UserName = user.UserName,
                    Photo = photoPath
                };
            }
            return null;
        }

        public async Task<string> GetUserProfilePhoto(string profilePhotoId) {
            string containerName = "profile-images";
            if (!string.IsNullOrEmpty(profilePhotoId)) {
                return $"{_configuration["BaseStorageUrl"]}/{containerName}/{profilePhotoId}";
            }
            else {
                return $"{_configuration["BaseStorageUrl"]}/{containerName}/default.png";
            }
        }

        public Task<GetTopTenResponse> GetTopTenUser() {
            return null;// _contentRateReadService
        }
    }
}
