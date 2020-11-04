﻿using Microsoft.AspNetCore.Http;

namespace Laboratorio5_EDII.Models
{
    public interface IRequestModel<T>
    {
        IFormFile File { get; set; }
        T Key { get; set; }
        string Name { get; set; }
        public string Cifrado { get; set; }
    }
}