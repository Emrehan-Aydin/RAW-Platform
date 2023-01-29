using Microsoft.AspNetCore.Mvc;

namespace RAW.Client.Controllers {
    public class MenuController : Controller {
        public IActionResult Index(MenuViewModel menuModel) {
            if (!string.IsNullOrEmpty(menuModel.Category)) {

                Response.Cookies.Append(menuModel.Category, "opened", new CookieOptions { Expires = (DateTime.Now.Add(new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay)) });
            }
            return View(menuModel);
        }
    }

}
