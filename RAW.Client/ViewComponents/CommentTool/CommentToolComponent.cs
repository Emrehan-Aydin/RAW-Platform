using Microsoft.AspNetCore.Mvc;
using RAW.Client.Dto;

namespace RAW.Client.ViewComponents.COmment {

    [ViewComponent(Name = "CommentTool")]
    public class CommentToolComponent : ViewComponent {
        private readonly HttpClient _client;

        public CommentToolComponent(HttpClient client) {
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string contentId) {
            return View("Index",new CommentModel() { ContentId=contentId});
        }

    }
}
