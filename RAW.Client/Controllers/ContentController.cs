using Microsoft.AspNetCore.Mvc;
using RAW.Client.Dto;
using RAW.Client.Helpers;
using RAW.Client.TokenService;
using RAWAPI.Domain.ApiRequest.Content;
using RAWAPI.Domain.Dtos.Response.Content;

namespace RAW.Client.Controllers {
    public class ContentController : Controller {
        private readonly ILogger<ContentController> _logger;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public ContentController(ILogger<ContentController> logger, HttpClient client, IConfiguration configuration) {
            _logger = logger;
            _client = client;
            _configuration = configuration;
        }

        public async Task<IActionResult> UploadVideo(UploadContentModel model) {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenHelper.GetCurrentUserToken(Request)}");

            var apiEndPoint = string.Format("{0}", "Content");
            UploadVideoContentDto uploadContent = new UploadVideoContentDto();
            uploadContent.UserId = TokenHelper.GetUserId(Request);
            uploadContent.Abstract = model.Abstract;
            uploadContent.ContentLink = model.Link;
            uploadContent.Anonymous = model.Anonymous;
            uploadContent.Category = model.Category;
            var result = await _client.PostAsJsonAsync(apiEndPoint, uploadContent);
            return await ReturnView(result);

        }

        public async Task<IActionResult> UploadImage(UploadContentModel model) {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenHelper.GetCurrentUserToken(Request)}");

            var apiEndPoint = string.Format("{0}", "Content");
            UploadImageContentDto uploadContent = new UploadImageContentDto();
            uploadContent.UserId = TokenHelper.GetUserId(Request);
            uploadContent.Abstract = model.Abstract;
            uploadContent.Anonymous = model.Anonymous;
            uploadContent.Category = model.Category;
            uploadContent.Content = RequestFileHelper.ReadPhotoInfo(Request);
            var result = await _client.PostAsJsonAsync(apiEndPoint, uploadContent);
            return await ReturnView(result);

        }

        public async Task<IActionResult> UploadMusic(UploadContentModel model) {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenHelper.GetCurrentUserToken(Request)}");

            var apiEndPoint = string.Format("{0}", "Content");
            UploadVideoContentDto uploadContent = new UploadVideoContentDto();
            uploadContent.UserId = TokenHelper.GetUserId(Request);
            uploadContent.Abstract = model.Abstract;
            uploadContent.ContentLink = model.Link;
            uploadContent.Anonymous = model.Anonymous;
            uploadContent.Category = model.Category;
            var result = await _client.PostAsJsonAsync(apiEndPoint, uploadContent);
            return await ReturnView(result);

        }

        public async Task<IActionResult> UploadDocument(UploadContentModel model) {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenHelper.GetCurrentUserToken(Request)}");

            var apiEndPoint = string.Format("{0}", "Content");
            UploadVideoContentDto uploadContent = new UploadVideoContentDto();
            uploadContent.UserId = TokenHelper.GetUserId(Request);
            uploadContent.Abstract = model.Abstract;
            uploadContent.Anonymous = model.Anonymous;
            uploadContent.Category = model.Category;
            var result = await _client.PostAsJsonAsync(apiEndPoint, uploadContent);
            return await ReturnView(result);
        }

        public async Task<IActionResult> UploadText(UploadContentModel model) {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {TokenHelper.GetCurrentUserToken(Request)}");

            var apiEndPoint = string.Format("{0}", "Content");
            UploadTextContentDto uploadContent = new UploadTextContentDto();
            uploadContent.UserId = TokenHelper.GetUserId(Request);
            uploadContent.Abstract = model.Abstract;
            uploadContent.Anonymous = model.Anonymous;
            uploadContent.Category = model.Category;
            var result = await _client.PostAsJsonAsync(apiEndPoint, uploadContent);
            return await ReturnView(result);
        }

        private async Task<IActionResult> ReturnView(HttpResponseMessage result) {
            try {

                if (result.IsSuccessStatusCode) {
                    UploadContentResponse response = await result.Content.ReadAsAsync<UploadContentResponse>();
                    return RedirectToAction("Index", "Menu", new {
                        menu = "UploadContent",
                        message = response.Message,
                        IsSucceed = response.IsSucceed
                    });
                }
                else {
                    return RedirectToAction("Index", "Menu", new {
                        menu = "UploadContent",
                        message = "Şu anda hizmet veremiyoruz. Özür Dileriz.",
                        IsSucceed = false
                    });
                }
            }
            catch (Exception) {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitRate(ContentRateModel model) {
            try {
                model.userId = TokenHelper.GetUserId(Request);
                var result = await _client.PostAsJsonAsync("Content/RateContent", model);
                CustomCookieHelper.SetRate(Request, Response, model.ContentId, model.Rate.ToString());
                var response = await result.Content.ReadAsAsync<ContentRateModel>();
                return Json(new { message = response.Message, isSuccess = response.IsSucceed });
            }
            catch (Exception) {
                return Json(new { message = "Hata oluştu", isSuccess = false });
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> SubmitComment(CommentModel model) {
            try {
                model.UserId = TokenHelper.GetUserId(Request);
                var result = await _client.PostAsJsonAsync("Content/CommentContent", model);
                var response = await result.Content.ReadAsAsync<CommentModel>();
                return Json(new { message = response.Message, isSuccess = response.IsSucceed });
            }
            catch (Exception) {
                return Json(new { message = "Hata oluştu", isSuccess = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoadComment(PaginationRequest req) {
            try {

                var response = await _client.PostAsJsonAsync("Comment", req);
                if (response.IsSuccessStatusCode) {
                    var content = await response.ReadContentAs<Dto.Pagination<CommentView>>();
                    if (content.IsSucceed) {
                        return content.Data.StopPaging ? Json("stopPaging") :
                        PartialView("~/Views/Shared/CommentPartial.cshtml", content.Data.Content);
                    }
                }
                return Json("");
            }
            catch (Exception ex) {
                return Json("");
            }
        }

    }
}
