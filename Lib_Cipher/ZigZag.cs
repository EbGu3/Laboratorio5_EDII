using System.Collections.Generic;
using System.Linq;

namespace Lib_Cipher
{
    public class Caracter
    {
        public List<byte> Car_List = new List<byte>();
    }
    public class ZigZag
    {
        public byte[] Cipher_ZigZag(byte[] txt, int levels)
        {
            Dictionary<int, Caracter> level_Dic = new Dictionary<int, Caracter>();
            List<byte> bytes_Exist = new List<byte>();
            var count = 0;
            while (count < levels)
            {
                var ini_List = new List<byte>();
                level_Dic.Add(count + 1, new Caracter
                {
                    Car_List = ini_List
                });
                count++;
            }

            var posLevel = 1;
            var elev = false;
            foreach (var item in txt)
            {
                if (!bytes_Exist.Contains(item))
                {
                    bytes_Exist.Add(item);
                }
                level_Dic.ElementAt(posLevel - 1).Value.Car_List.Add(item);
                if (!elev)
                {
                    if (posLevel == levels)
                    {
                        posLevel--;
                        elev = true;
                    }
                    else
                    {
                        posLevel++;
                    }
                }
                else
                {
                    if (posLevel == 1)
                    {
                        posLevel++;
                        elev = false;
                    }
                    else
                    {
                        posLevel--;
                    }
                }
            }
            byte filler = 36;
            if (!bytes_Exist.Contains(36))
            {
                filler = 254;
                while (bytes_Exist.Contains(filler))
                {
                    filler--;
                }
            }
            var caracteresExtra = 0;
            while (posLevel - 1 != 1)
            {
                caracteresExtra++;
                level_Dic.ElementAt(posLevel - 1).Value.Car_List.Add(filler);
                if (!elev)
                {
                    if (posLevel == levels)
                    {
                        posLevel--;
                        elev = true;
                    }
                    else
                    {
                        posLevel++;
                    }
                }
                else
                {
                    if (posLevel == 1)
                    {
                        posLevel++;
                        elev = false;
                    }
                    else
                    {
                        posLevel--;
                    }
                }

            }
            var cipherTxt = new byte[txt.Length + caracteresExtra];
            var ladder = 0;
            var pos = 0;
            while (ladder < levels)
            {
                foreach (var item in level_Dic.ElementAt(ladder).Value.Car_List)
                {
                    cipherTxt[pos] = item;
                    pos++;
                }

                ladder++;
            }

            return cipherTxt;
        }
    }
}
