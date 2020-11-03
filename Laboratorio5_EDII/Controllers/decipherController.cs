using Microsoft.AspNetCore.Mvc;
using Laboratorio5_EDII.Models;

namespace Laboratorio5_EDII.Controllers
{
    [Route("api/[controller]")]
    public class decipherController : Controller
    {
        /// <summary>
        /// Recibe el archivo a desifrar
        /// </summary>
        ///<response code="200">Archivo descifrado exitosamente</response>
        ///<response code="500">Archivo corrupto</response>
        /// <param name="method"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Descifrado()
        {

            return Ok();
        }
    }
}
