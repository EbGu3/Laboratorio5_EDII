using System.IO;
using System.Text;

namespace Lib_Cipher
{
    public class Cesar
    {
        public string CipherCesarLoop(string initialtxt, int Key)
        {
            int t;
            var letter = initialtxt.Length;
            char[] ch = new char[letter];
            var res = string.Empty;
            for (int i = 0; i < letter; i++)
            {
                t = (int)initialtxt[i];
                ch[i] = (char)(t + Key);
                res = res + ch[i];
            }
            return res;
        }
        public string DecipherCesarLoop(string Initialtxt, int Key)
        {
            int t;
            var letter = Initialtxt.Length;
            char[] ch = new char[letter];
            var res = string.Empty;
            for (int i = 0; i < letter; i++)
            {
                t = (int)Initialtxt[i];
                ch[i] = (char)(t - Key);
                res = res + ch[i];
            }
            return res;
        }
    }
}
