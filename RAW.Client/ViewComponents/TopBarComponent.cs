using Microsoft.AspNetCore.Mvc;
using RAWAPI.Domain.Dtos.Request.DashBoard;
using RAW.Client.Helpers;
using RAW.Client.TokenService;

namespace RAW.Client.ViewComponents {

    [ViewComponent(Name = "TopBar")]
    public class TopBarComponent : ViewComponent {
        private readonly HttpClient _client;

        public TopBarComponent(HttpClient client) {
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync() {
            if (string.IsNullOrEmpty(Request.Cookies["Token"])) {
                return View(@"~\Views\Error\Index.cshtml");
            }
            else {
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenHelper.GetCurrentUserToken(Request)}");
                var response = await _client.GetAsync($"Users/GetUserDashboardInfo/{TokenHelper.GetUserId(Request)}");
                if (response.IsSuccessStatusCode) {
                    var data = await response.ReadContentAs<UserDashboardDto>();
                    data.Data.Photo = string.IsNullOrEmpty(data.Data.Photo) ? "https://rawproject.blob.core.windows.net/profile-images/default.png" : data.Data.Photo;
                    return View("Index", data.Data);
                }
                return View("Error");
            }
        }

    }
}
