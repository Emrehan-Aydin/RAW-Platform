using Microsoft.AspNetCore.Mvc;
using RAW.Client.Helpers;
using RAW.Client.ViewModels;

namespace RAW.Client.ViewComponents {
    [ViewComponent(Name = "TextContent")]
    public class TextContent : ViewComponent {
        private readonly HttpClient _client;

        public TextContent(HttpClient client) {
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string category) {
            try {
                var response = await _client.GetAsync($"Content/GetDailyContent/{category}");
                if (response.IsSuccessStatusCode) {
                    var content = await response.ReadContentAs<ContentViewModel>();
                    if (content.IsSucceed) {
                        content.Data.IsSucceed = true;
                        content.Data.UserRate = CustomCookieHelper.GetRate(Request, content.Data.Id.ToString());
                        return View("Index", content.Data);
                    }
                    else {
                        return View("Index",new ContentViewModel {
                            IsSucceed= content.IsSucceed,
                            Message = content.Message
                        });
                    }
                }
                else {
                    throw new Exception("HATA OLUŞTU");
                }

            }
            catch (Exception) {
                return View("Index", new ContentViewModel {
                    IsSucceed = false,
                    Message = "Teknik bir aksaklıktan dolayı hizmet veremiyoruz!"
                });
            }
        }
    }
}
