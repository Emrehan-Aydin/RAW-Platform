using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RAW.Client.Helpers;
using RAW.Client.TokenService;
using RAWAPI.Domain.Common;
using RAWAPI.Domain.Dtos.Request.DashBoard;
using RAWAPI.Domain.Dtos.Request.Profile;
using RAWAPI.Domain.Dtos.Response.Profile;

namespace RAW.Client.Controllers {
    public class ProfileController : Controller {
        private readonly ILogger<ProfileController> _logger;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment environment;

        public ProfileController(ILogger<ProfileController> logger, HttpClient client, IConfiguration configuration, IWebHostEnvironment _environment) {
            _logger = logger;
            _client = client;
            _configuration = configuration;
            environment = _environment;
        }
        public async Task<IActionResult> IndexAsync() {
            try {
                TokenHelper.GetUserId(Request);
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenHelper.GetCurrentUserToken(Request)}");
                var response = await _client.GetAsync($"Users/GetProfileDashboardInfo/{TokenHelper.GetUserId(Request)}");
                if (response.IsSuccessStatusCode) {
                    var content = await response.ReadContentAs<GetUserProfileResponse>();
                    return View(content.Data);
                }
                else {
                    return RedirectToAction("Index", "Error", routeValues: "Profil bilgisine ulaşılamıyor!");

                }
            }
            catch (Exception ex) {
                return RedirectToAction("Index", "Error", routeValues: ex.Message);
            }
        }

        public async Task<IActionResult> UpdateProfile(GetUserProfileResponse request) {
            UpdateProfileRequest updateProfileRequest = JSON.Map<GetUserProfileResponse, UpdateProfileRequest>(request);
            updateProfileRequest.UserId = TokenHelper.GetUserId(Request);
            updateProfileRequest.profilePhoto = RequestFileHelper.ReadPhotoInfo(Request);
            var result = await _client.PostAsJsonAsync("Users/UpdateProfile", updateProfileRequest);
            if (result.IsSuccessStatusCode) {
                return RedirectToAction("Index", "Profile");
            }
            else {
                return RedirectToAction("Index", "Error", routeValues: "Güncelleme işlemi sırasında hata oluştu!");
            }
        }

        public async Task<IActionResult> ShowProfile(string userId) {
            try {
                TokenHelper.GetUserId(Request);
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenHelper.GetCurrentUserToken(Request)}");
                var response = await _client.GetAsync($"Users/GetProfileDashboardInfo/{TokenHelper.GetUserId(Request)}");
                if (response.IsSuccessStatusCode) {
                    var content = await response.ReadContentAs<GetUserProfileResponse>();
                    return View(content.Data);
                }
                else {
                    return RedirectToAction("Index", "Error", routeValues: "Profil bilgisine ulaşılamıyor!");

                }
            }
            catch (Exception ex) {
                return RedirectToAction("Index", "Error", routeValues: ex.Message);
            }

        }
    }
}
