using Microsoft.AspNetCore.Mvc;
using Laboratorio5_EDII.Models;

namespace Laboratorio5_EDII.Controllers
{
    [Route("api/[controller]")]
    public class decipherController : Controller
    {
        [HttpPost]
        public ActionResult Descifrado()
        {

            return Ok();
        }
    }
}
