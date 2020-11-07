using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using Lib_Cipher;
using System.Text;

namespace Laboratorio5_EDII.Models
{
    /// <summary>
    /// Manejo del archivo cifrado o desifrado
    /// </summary>
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
            if (!Directory.Exists($"Cipher"))
            {
                Directory.CreateDirectory($"Cipher");
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
            if (!Directory.Exists($"Decipher"))
            {
                Directory.CreateDirectory($"Decipher");
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
        public void Cipher_Cesar(string path, string key)
        {
            Cesar cesar = new Cesar();
            var path_exported = Path.Combine($"Cipher", Path.GetFileNameWithoutExtension(path) + ".csr");
            cesar.Cipher_Decipher(path, key, true, path_exported);
        }

        /// <summary>
        /// Desifrado cesar
        /// </summary>
        /// <param name="path"></param>
        /// <param name="key"></param>
        public void Decipher_Cesar(string path, string key)
        {
            Cesar cesar = new Cesar();
            var path_exported = Path.Combine($"Decipher", Path.GetFileNameWithoutExtension(path) + ".txt");
            cesar.Cipher_Decipher(path, key, false, path_exported);
        }

        /// <summary>
        /// Cifrado ZigZag
        /// </summary>
        /// <param name="path"></param>
        /// <param name="levels"></param>
        /// <param name="formFile"></param>
        public void Cipher_ZigZag(string path, int levels, IFormFile formFile)
        {
            var fileByte = new byte[formFile.Length];
            var i = 0;
            using (var lectura = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (lectura.BaseStream.Position != lectura.BaseStream.Length)
                {
                    fileByte[i] = lectura.ReadByte();
                    i++;
                }
            }
            ZigZag zigZag = new ZigZag();
            var txtDesifrado = zigZag.Cipher(fileByte, levels);
            var txtResultado = new byte[1];
            txtResultado = new byte[txtDesifrado.Length];
            txtResultado = txtDesifrado;
            var new_Path = Path.Combine($"Cipher", Path.GetFileNameWithoutExtension(path) + ".zz");
            save_File(new_Path, txtResultado);
        }

        /// <summary>
        /// Desifrado ZigZag
        /// </summary>
        public void Decipher_ZigZag(int levels, IFormFile formFile, string path)
        {
            var fileByte = new byte[formFile.Length];
            var i = 0;
            using (var lectura = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (lectura.BaseStream.Position != lectura.BaseStream.Length)
                {
                    fileByte[i] = lectura.ReadByte();
                    i++;
                }
            }
            ZigZag zigZag = new ZigZag();
            var txtCifrado = zigZag.Decipher(fileByte, levels);
            var txtResultado = new byte[1];
            txtResultado = new byte[txtCifrado.Length];
            txtResultado = txtCifrado;
            var new_Path = Path.Combine($"Decipher", Path.GetFileNameWithoutExtension(path) + ".txt");
            save_File(new_Path, txtResultado);
        }

        private void save_File(string new_Path, byte[] txtResultado)
        {
            using (var writeStream = new FileStream(new_Path, FileMode.OpenOrCreate))
            {
                using (var writer = new BinaryWriter(writeStream))
                {
                    writer.Write(txtResultado);
                }
            }
        }

        /// <summary>
        /// Cifrado ruta
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="file"></param>
        /// <param name="route"></param>
        public void Cipher_Route(int m, int n, IFormFile file, string route)
        {
            Route routeCipher = new Route(m, n, Get_allText(file));
            if (route.ToLower().Equals("vertical"))
            {
                var txt = routeCipher.Cipher_Vertical();
                var new_path = Path.Combine($"Cipher", Path.GetFileNameWithoutExtension(file.FileName) + ".rt");
                var textByte = Encoding.ASCII.GetBytes(txt);
                save_File(new_path,textByte);

            }
            else if (route.ToLower().Equals("espiral"))
            {
                var txt = routeCipher.Cipher_Spiral();
                var new_path = Path.Combine($"Cipher", Path.GetFileNameWithoutExtension(file.FileName) + ".rt");
                var textByte = Encoding.ASCII.GetBytes(txt);
                save_File(new_path, textByte);
            }
        }

        /// <summary>
        /// Desifrado tipo Ruta
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="file"></param>
        /// <param name="route"></param>
        public void Decipher_Route(int m, int n, IFormFile file, string route)
        {
            Route routeCipher = new Route(m, n, Get_allText(file));
            if (route.ToLower().Equals("vertical"))
            {
                routeCipher.decipher_Vertical();
            }
            else if (route.ToLower().Equals("espiral"))
            {
                routeCipher.Decipher_Spiral();
            }
        }

        /// <summary>
        /// Busca y guarda el string del archivo
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string Get_allText(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }
            return result.ToString();
        }
    }
}
