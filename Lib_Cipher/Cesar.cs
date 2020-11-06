using System.IO;
using System.Text;

namespace Lib_Cipher
{
    public class Cesar
    {
        public void TodoCesar(FileStream ArchivoImportado, int Key, string opcion)
        {
            var nombreArchivo = Path.GetFileNameWithoutExtension(ArchivoImportado.Name);
            ArchivoImportado.Close();
            using (var Lectura = new StreamReader(("Mis Cifrados/" + nombreArchivo + ".txt"), Encoding.ASCII, true))
            {
                var txtInicio = Lectura.ReadToEnd();
                var txtFinal = string.Empty;
                if (opcion == "Cifrado")
                {
                    txtFinal = CifrarCesar(txtInicio, Key);
                }
                else
                {
                    txtFinal = DesifrarCesar(txtInicio, Key);
                }
                using (var writeStream = new FileStream(("Mis Cifrados/" + opcion + "_" + nombreArchivo + ".txt"), FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(writeStream))
                    {
                        writer.Write(txtFinal);
                    }
                }
            }
        }
        public string CifrarCesar(string txtInicial, int Key)
        {
            int t;
            var Letras = txtInicial.Length;
            char[] ch = new char[Letras];
            var Resultante = string.Empty;
            for (int i = 0; i < Letras; i++)
            {
                t = (int)txtInicial[i];
                ch[i] = (char)(t + Key);
                Resultante = Resultante + ch[i];
            }
            return Resultante;
        }
        public string DesifrarCesar(string txtInicial, int Key)
        {
            int t;
            var Letras = txtInicial.Length;
            char[] ch = new char[Letras];
            var Resultante = string.Empty;
            for (int i = 0; i < Letras; i++)
            {
                t = (int)txtInicial[i];
                ch[i] = (char)(t - Key);
                Resultante = Resultante + ch[i];
            }
            return Resultante;
        }
    }
}
