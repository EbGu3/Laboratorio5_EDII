﻿using Microsoft.AspNetCore.Http;
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
        /// <returns></returns>
        public bool Get_Cipher(string Medodo, Required values)
        {
            if ((TypeOfFile(values.File.FileName) == true) && (ContainsData(values.File) == true))
            {
                switch (Medodo.ToLower())
                {
                    case "cesar":
                        if (values.Key == null || int.TryParse(values.Key, out int keyOut)) { return false; }
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
                            fileHandeling.Cipher_ZigZag(new_Path.Result, lvl, values.File);
                            return true;
                        }
                    case "ruta":
                        var matrix = values.Key.Split(",");
                        try
                        {
                            if (int.Parse(matrix[0]) > 0 && int.Parse(matrix[1]) > 0)
                            {
                                var m = int.Parse(matrix[0]);
                                var n = int.Parse(matrix[1]);
                                FileHandeling fileHandeling = new FileHandeling();
                                fileHandeling.Cipher_Route(m,n, values.File, values.Route);

                            }
                        }
                        catch (System.Exception)
                        {
                            return false;
                        }
                        
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
