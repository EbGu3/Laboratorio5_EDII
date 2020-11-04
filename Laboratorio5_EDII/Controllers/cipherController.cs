using Microsoft.AspNetCore.Mvc;
using Laboratorio5_EDII.Models;

namespace Laboratorio5_EDII.Controllers
{
    [Route("api/[controller]")]
    public class cipherController : Controller
    {
        /// <summary>
        /// Recibe el archivo a cifrar junto al método de cifrado
        /// </summary>
        ///<response code="200">Archivo cifrado exitosamente</response>
        ///<response code="500">Archivo corrupto</response>
        /// <param name="method"></param>
        /// <returns></returns>
        [HttpPost, Route("{method}")]
        public ActionResult Cifrado(Required values, string method)
        {
            cipherType cipherType = new cipherType();
            var cipher = cipherType.Get_Cipher(method,values);
            var result1 = cipherType.TypeOfFile(values);
            var result2 = cipherType.ContainsData(values);
            if (cipher)
            {

            }
            return Ok();
        }
    }
}
