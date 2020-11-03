using Microsoft.AspNetCore.Mvc;
using Laboratorio5_EDII.Models;

namespace Laboratorio5_EDII.Controllers
{
    [Route("api/[controller]")]
    public class cipherController : Controller
    {
        [HttpPost, Route("method")]
        public ActionResult Cifrado()
        {

            return Ok();
        }
    }
}
