using Microsoft.AspNetCore.Http;

namespace Laboratorio5_EDII.Models
{
    public class Required : IRequestModel<string>
    {
        public IFormFile File { get; set; }
        public string Key { get; set; }
        public string Route { get; set; }
    }
}
