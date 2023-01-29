using Microsoft.AspNetCore.Mvc;
using RAW.Client.Dto;

namespace RAW.Client.ViewComponents.COmment {

    [ViewComponent(Name = "Comment")]
    public class CommentComponent : ViewComponent {
        private readonly HttpClient _client;

        public CommentComponent(HttpClient client) {
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string contentId) {
            return View("Index",new Dto.Pagination<CommentView>() { ContentId = contentId });
        }

    }
}
