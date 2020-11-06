using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lib_Cipher
{
    public class Cesar
    {
        public void Cipher_Cesar(string path, string key, bool option, string extention)
        {
            int bufferLength = 100;
            var dicctionary = Dicctionary_Cesar(key, option);
            using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                var name = Path.GetFileNameWithoutExtension(path);
                var old_name = Path.GetFileName(path);
                path = path.Replace(old_name, string.Empty);
                var new_Path = Path.Combine(path, name + extention);
                using (var writeStream = new FileStream(new_Path, FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(writeStream))
                    {
                        var byteBuffer = new byte[bufferLength];
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            byteBuffer = reader.ReadBytes(bufferLength);
                            foreach (var item in byteBuffer)
                            {
                                if (dicctionary.ContainsKey(Convert.ToChar(item)))
                                {
                                    var ByteEscrito = dicctionary[Convert.ToChar(item)];
                                    writer.Write(ByteEscrito);
                                }
                                else
                                {
                                    writer.Write(item);
                                }
                            }
                        }
                    }
                }
            }
        }
        public Dictionary<char, char> Dicctionary_Cesar(string usrKey, bool option)
        {
            var dicCipher = new Dictionary<char, char>();
            var key = usrKey.ToCharArray();
            var indexStarter = 65;         
            foreach (var item in key)
            {
                if (!(indexStarter >= 91 && indexStarter <= 96))
                {
                    if (!dicCipher.ContainsValue(item))
                    {
                        dicCipher.Add(Convert.ToChar(indexStarter), item);
                        indexStarter++;
                    }
                }
            }
            for (int i = 65; i < 123; i++)
            {
                if (!(indexStarter >= 91 && indexStarter <= 96))
                {
                    if (!dicCipher.ContainsValue(Convert.ToChar(i)) && !(i >= 91 && i <= 96))
                    {
                        dicCipher.Add(Convert.ToChar(indexStarter), Convert.ToChar(i));
                        indexStarter++;
                    }
                }
                else
                {
                    i--;
                    indexStarter++;
                }
            }
            if (!option)
            {
                dicCipher = dicCipher.ToDictionary(kp => kp.Value, kp => kp.Key);
            }
            return dicCipher;
        }
    }
}
