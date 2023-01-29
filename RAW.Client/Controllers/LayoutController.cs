using Microsoft.AspNetCore.Mvc;

namespace RAW.Client.Controllers {
    public class LayoutController : Controller {
        public IActionResult Index() {

            return View();
        }
    }
}
