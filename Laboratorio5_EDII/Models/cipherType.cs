using Microsoft.AspNetCore.Http;
using System.IO;

namespace Laboratorio5_EDII.Models
{
    /// <summary>
    /// División entre cifrado y desifrado
    /// </summary>
    public class cipherType
    {
        /// <summary>
        /// Obtiene la forma del cifrado
        /// </summary>
        /// <param name="Medodo"></param>
        /// <param name="key"></param>
        /// <param name="file"></param>
        /// <param name="Columns"></param>
        /// <param name="Rows"></param>
        /// <returns></returns>
        public bool Get_Cipher(string Medodo, string key, IFormFile file, int Columns, int Rows)
        {
            if (key is null)
            {
                throw new System.ArgumentNullException(nameof(key));
            }

            if ((TypeOfFile(file.FileName) == true) && (ContainsData(file) == true))
            {
                switch (Medodo.ToLower())
                {
                    case "cesar":
                        if (key == null || int.TryParse(key, out int keyOut)) { return false; }
                        else
                        {
                            FileHandeling fileHandeling = new FileHandeling();
                            fileHandeling.Create_File_Import();
                            var new_Path = fileHandeling.Import_FileAsync(file);
                            fileHandeling.Cipher_Cesar(new_Path.Result, key);

                            return true;
                        }
                    case "zigzag":
                        var level = int.TryParse(key, out int lvl);
                        if (!level || lvl <= 0) { return false; }
                        else
                        {
                            FileHandeling fileHandeling = new FileHandeling();
                            fileHandeling.Create_File_Import();
                            var new_Path = fileHandeling.Import_FileAsync(file);
                            fileHandeling.Cipher_ZigZag(new_Path.Result, lvl, file);
                            return true;
                        }
                    case "ruta":
                            
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Obtiene la forma del cifrado
        /// </summary>
        /// <param name="file"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public bool Get_Decipher(IFormFile file, string Key)
        {
            var extention = Path.GetExtension(file.FileName);
            switch (extention)
            {
                case ".csr":
                    FileHandeling fileHandeling = new FileHandeling();
                    fileHandeling.Create_File_Export();
                    var new_Path = fileHandeling.Import_FileAsync(file);
                    fileHandeling.Decipher_Cesar(new_Path.Result, Key);
                    return true;
                case ".zz":
                    var level = int.TryParse(Key, out int lvl);
                    if (!level || lvl <= 0) { return false; }
                    else
                    {
                        FileHandeling fileHandeling1 = new FileHandeling();
                        fileHandeling1.Create_File_Export();
                        var newer_Path = fileHandeling1.Import_FileAsync(file);
                        fileHandeling1.Decipher_ZigZag(lvl, file, newer_Path.Result);
                    }
                    return true;
                case ".rt":
                    return true;
            }
            return false;
        }

        public bool TypeOfFile(string value) => (Path.GetExtension(value).Equals(".txt"));
        public bool ContainsData(IFormFile values) => (values != null);

    }
}
