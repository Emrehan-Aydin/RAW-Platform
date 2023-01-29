using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RAW.Client.Dto;
using RAW.Client.Helpers;
using RAW.Client.TokenService;
using RAWAPI.Domain.Dtos.Request.User;
using RAWAPI.Domain.Dtos.Response.User;
using RAWAPI.Domain.Entities.File;
using static Google.Apis.Requests.BatchRequest;

namespace RAW.Client.Controllers {
    public class LoginController : Controller {
        private readonly ILogger<LoginController> _logger;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment environment;

        public LoginController(ILogger<LoginController> logger, HttpClient client, IConfiguration configuration, IWebHostEnvironment _environment) {
            _logger = logger;
            _client = client;
            _configuration = configuration;
            environment = _environment;
        }

        public IActionResult Index(LoginRequestDto model) {
            CustomCookieHelper.InitializeMenuCookie(Request,Response);
            return View(model);
        }

        public async Task<IActionResult> Login(LoginRequestDto request) {
            try {
                TokenHelper.ClearToken(Response);
                var apiEndPoint = string.Format("{0}/{1}", "Auth", "Login");
                var result = await _client.PostAsJsonAsync(apiEndPoint, request);
                var response = await result.Content.ReadAsAsync<LoginUserCommandResponse>();
                if (result.IsSuccessStatusCode && response.IsSucceed) {
                    TokenHelper.SaveToken(Response, response.Token.AccessToken);
                    _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenHelper.GetCurrentUserToken(Request)}");
                    return RedirectToAction("Index", "Dashboard");
                }
                else {
                    return RedirectToAction("Index",new LoginRequestDto() {
                        IsSucceed = false,
                        Message = response.Message
                    });
                }
            }
            catch (Exception ex) {
                return RedirectToAction("Index", "Error", routeValues: ex.Message);
            }

        }

        public IActionResult Register() {
            return View();
        }

        public async Task<IActionResult> CreateUser([FromForm] RAWAPI.Domain.Dtos.Request.User.CreateUserRequest request) {
            request.CreateProfileCommandRequest.profilePhoto = new ImageFile();
            request.CreateProfileCommandRequest.profilePhoto.FileBytes = new byte[0];
            request.CreateProfileCommandRequest.profilePhoto.FileExtension = "default";
            if (Request.Form.Files.Count == 1) {
                using (MemoryStream ms = new MemoryStream()) {
                    Request.Form.Files[0].CopyTo(ms);
                    request.CreateProfileCommandRequest.profilePhoto.FileBytes = ms.ToArray();
                    request.CreateProfileCommandRequest.profilePhoto.FileName = Guid.NewGuid().ToString();
                    request.CreateProfileCommandRequest.profilePhoto.FileExtension = Request.Form.Files[0].FileName.Split('.').Last();
                }
            }

            var apiEndPoint = string.Format("{0}", "Users");
            var result = await _client.PostAsJsonAsync(apiEndPoint, request);
            if (result.IsSuccessStatusCode) {
                return RedirectToAction("Login", new LoginRequestDto {
                    UsernameOrEmail = request.CreateUserCommandRequest.Username,
                    Password = request.CreateUserCommandRequest.Password
                });
            }
            return View("Register");

        }

        public IActionResult Logout() {
            Response.Cookies.Delete("Token");
            return RedirectToAction(actionName:"Index",controllerName:"Login");
        }

    }
}
