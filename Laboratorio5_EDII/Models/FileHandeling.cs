using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using Lib_Cipher;
using System.Text;

namespace Laboratorio5_EDII.Models
{
    public class FileHandeling
    {
        /// <summary>
        /// Create Upload and Compress files
        /// </summary>
        public void Create_File_Import()
        {
            if (!Directory.Exists($"Upload"))
            {
                Directory.CreateDirectory($"Upload");
            }
            if (!Directory.Exists($"Compress"))
            {
                Directory.CreateDirectory($"Compress");
            }
        }
        /// <summary>
        /// Create Upload and Decompress files
        /// </summary>
        public void Create_File_Export()
        {
            if (!Directory.Exists($"Upload"))
            {
                Directory.CreateDirectory($"Upload");
            }
            if (!Directory.Exists($"Decompress"))
            {
                Directory.CreateDirectory($"Decompress");
            }
        }
        /// <summary>
        /// Importa el archivo a la carpeta UPLOAD para ser trabajado luego
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public async Task<string> Import_FileAsync(IFormFile formFile)
        {
            var new_Path = string.Empty;
            var path = Path.Combine($"Upload", formFile.FileName);
            using (var this_file = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(this_file);
                new_Path = Path.GetFullPath(this_file.Name);
            }
            return new_Path;
        }

        /// <summary>
        /// Cifrado Cesar
        /// </summary>
        /// <param name="path"></param>
        /// <param name="key"></param>
        /// <param name="fileName"></param>
        public void Cipher_Cesar(string path, string key, string fileName)
        {
            var finalTxt = string.Empty;
            var test = !(int.TryParse(key, out int testeo));
            Cesar cesar = new Cesar();
            using (var reader = new StreamReader(path, Encoding.ASCII, true))
            {
                var txtInicio = reader.ReadToEnd();
                if (!(int.TryParse(key, out int Key)))
                {
                    finalTxt = cesar.CipherCesarLoop(txtInicio, Key);
                }
            }
            save_File($"Cipher/" + fileName, finalTxt);
        }

        public void Decipher_Cesar()
        {

        }

        public void Cipher_ZigZag(string fileName, string path, int levels)
        {
            var txtFinal = string.Empty;

            save_File($"Cipher/" + fileName, txtFinal);
        }

        public void Decipher_ZigZag()
        {

        }

        public void Cipher_Route(string fileName)
        {
            var txtFinal = string.Empty;

            save_File($"Cipher/" + fileName, txtFinal);
        }

        public void Decipher_Route()
        {

        }

        /// <summary>
        /// Guarda el archivo cifrado
        /// </summary>
        /// <param name="path"></param>
        /// <param name="txtFinal"></param>
        public void save_File(string path, string txtFinal)
        {
            using (var writeStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var writer = new BinaryWriter(writeStream))
                {
                    writer.Write(txtFinal);
                }
            }
        }
    }
}
