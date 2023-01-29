using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RAWAPI.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        public IActionResult Get() {
            return Ok("TEST");
        }
    }
}
