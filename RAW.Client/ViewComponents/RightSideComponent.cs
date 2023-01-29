using Microsoft.AspNetCore.Mvc;

namespace RAW.Client.ViewComponents {

    [ViewComponent(Name = "RightSide")]
    public class RightSideComponent : ViewComponent {
        private readonly HttpClient _client;

        public RightSideComponent(HttpClient client) {
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync() {
            return View("Index");
        }

    }
}
