using Microsoft.AspNetCore.Mvc;
using RAW.Client.TokenService;

namespace RAW.Client.Controllers {
    public class DashboardController : Controller {
        public IActionResult Index() {
            if (TokenHelper.IsAuth(Request)) {
                return View();
            }
            else {
                return View("~/Views/Error/Index.cshtml", "Yetkisiz Erişim!");
            }
        }
    }
}
