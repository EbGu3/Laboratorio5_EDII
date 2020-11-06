using Microsoft.AspNetCore.Http;
using System.IO;

namespace Laboratorio5_EDII.Models
{
    public class cipherType
    {
        /// <summary>
        /// Obtiene la forma del cifrado
        /// </summary>
        /// <param name="values"></param>
        /// <param name="Medodo"></param>
        /// <returns></returns>
        public bool Get_Cipher(Required values, string Medodo)
        {
            if ((TypeOfFile(values.File.FileName) == true) && (ContainsData(values.File) == true))
            {
                switch (Medodo.ToLower())
                {
                    case "cesar":
                        if (values.Key == null || int.TryParse(values.Key, out int Key)) { return false; }
                        else
                        {
                            FileHandeling fileHandeling = new FileHandeling();
                            fileHandeling.Create_File_Import();
                            var new_Path = fileHandeling.Import_FileAsync(values.File);
                            fileHandeling.Cipher_Cesar(new_Path.Result, values.Key);

                            return true;
                        }
                    case "zigzag":
                        var level = int.TryParse(values.Key, out int lvl);
                        if (!level || lvl <= 0) { return false; }
                        else
                        {
                            FileHandeling fileHandeling = new FileHandeling();
                            fileHandeling.Create_File_Import();
                            var new_Path = fileHandeling.Import_FileAsync(values.File);
                            fileHandeling.Cipher_ZigZag(values.File.FileName, new_Path.Result, lvl, values.File);
                            return true;
                        }
                    case "ruta":
                        if (values.Reloj != "Abajo") { return false; }
                        else { return true; }
                }
            }
            return false;
        }
        public bool TypeOfFile(string value) => (Path.GetExtension(value).Equals(".txt"));
        public bool ContainsData(IFormFile values) => (values != null);

    }
}
