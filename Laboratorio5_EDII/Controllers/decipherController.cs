using Microsoft.AspNetCore.Mvc;
using Laboratorio5_EDII.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

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
        /// <returns></returns>
        [HttpPost]
        public ActionResult Descifrado(Required values)
        {
            cipherType cipherType = new cipherType();
            var cipher = cipherType.Get_Decipher(values.File, values.Key, values.Ancho, values.Filas);
            if (cipher)
            {
                return Ok("Archivo cifrado exitosamente.");
            }
            else
            {
                return StatusCode(500, "Algún parametro se encuentra erroneo.");
            }
        }
    }
}
