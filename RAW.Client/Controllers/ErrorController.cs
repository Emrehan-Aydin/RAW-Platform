using Microsoft.AspNetCore.Mvc;

namespace RAW.Client.Controllers {
    public class ErrorController : Controller {
        public IActionResult Index(string message) {
            if (string.IsNullOrEmpty(message)) {
                message = "HATA OLUŞTU!";
            }
            return View(model:message);
        }
    }
}
