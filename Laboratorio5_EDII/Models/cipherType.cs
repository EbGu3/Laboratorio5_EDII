using System.IO;

namespace Laboratorio5_EDII.Models
{
    public class cipherType
    {
        public bool Get_Cipher(string method, Required values)
        {
            if (method.ToLower() == "cesar")
            {
                if (values.File == null)
                {
                    return false;
                }
                else if (Path.GetExtension(values.File.FileName) != ".txt")
                {
                    return false;
                }
                else if (values.Key == null || !(int.TryParse(values.Key, out int Key)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (method.ToLower() == "zigzag")
            {
                if (values.File == null)
                {
                    return true;
                }
                else if (Path.GetExtension(values.File.FileName) != ".txt")
                {
                    return true;
                }
                else if (values.Niveles == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (method.ToLower() == "espiral")
            {
                if (values.File == null)
                {
                    return false;
                }
                else if (Path.GetExtension(values.File.FileName) != ".txt")
                {
                    return false;
                }
                else if (values.Ancho == 0)
                {
                    return false;
                }
                else if (!(values.Reloj == "Abajo"))
                {
                    return false;
                }
                else
                {

                }
            }
            return false;
        }

        public bool Get_Cipher(Required values, string Medodo)
        { 
            if((TypeOfFile(values) == true) && (ContainsData(values) == true))
            {
                switch (Medodo.ToLower())
                {
                    case "cesar":
                        if (values.Key == null || !(int.TryParse(values.Key, out int Key))) { return false; }
                        else { return true; }
                        break;
                    case "zigzag":
                        if (values.Niveles == 0) { return false}
                        else { return true; }
                        break;
                    case "ruta":
                        if (values.Reloj != "Abajo") { return false; }
                        else { return true; }
                        break;
                }
            }
            return false;
        }
        public bool TypeOfFile(Required values) => (Path.GetExtension(values.File.FileName).Equals(".txt"));
        public bool ContainsData(Required values) => (values.File == null);
        
    }
}
