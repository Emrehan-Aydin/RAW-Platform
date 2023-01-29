using Microsoft.AspNetCore.Mvc;
using RAW.Client.Dto;
using System.Xml.Linq;

namespace RAW.Client.ViewComponents {
    [ViewComponent(Name = "UploadContent")]
    public class UploadContent : ViewComponent {
        private readonly HttpClient _client;

        public UploadContent(HttpClient client) {
            _client = client;
        }
        public IViewComponentResult Invoke(UploadContentModel model) {
            return View("Index", new UploadContentModel {
                IsSucceed = model.IsSucceed,
                Message = model.Message
            });
        }
    }

}
