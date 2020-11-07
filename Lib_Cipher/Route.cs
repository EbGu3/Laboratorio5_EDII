using System.IO;

namespace Lib_Cipher
{
    public class Route
    {
        #region values Class
        int m { get; set; }
        int n { get; set; }
        string text { get; set; }

        char[,] matrix;
        #endregion

        public Route(int m, int n, string text)
        {
            this.m = m;
            this.n = n;
            matrix = new char[m, n];

            //Elimina el caracter -\r\n- que agrega el stringbuilder al final de todo el texto
            text = text.Remove(text.Length - 1);
            text = text.Remove(text.Length - 1);
            this.text = text;
        }

        public string Cipher_Vertical()
        {
            int cont = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (cont != text.Length)
                    {
                        matrix[j, i] = text[cont];
                    }
                    else
                    {
                        matrix[j, i] = '#';
                    }
                    cont++;
                }
            }
            string outPut = "";
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    outPut += matrix[i, j];
                }
            }
            return outPut;
        }

        public string decipher_Vertical()
        {
            int cont = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = text[cont];
                    cont++;
                }
            }

            string outPut = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    outPut += matrix[j, i];
                }
            }
            outPut = outPut.Replace('#', ' ');
            return outPut;
        }

        public string Cipher_Spiral()
        {
            int cont = 0;

            bool right = true, down = false, left = false, up = false;
            int x = 0, y = 0;
            for (int i = 0; i < m * n; i++)
            {
                if (right)
                {
                    if (y < n && matrix[x, y] == '\0')
                    {
                        matrix[x, y] = (cont < text.Length) ? text[cont] : '#';
                        cont++;
                        y++;
                    }
                    else
                    {
                        y--;
                        x++;
                        right = false;
                        down = true;
                        i--;
                    }
                }
                else if (down)
                {
                    if (x < m && matrix[x, y] == '\0')
                    {
                        matrix[x, y] = (cont < text.Length) ? text[cont] : '#';
                        cont++;
                        x++;
                    }
                    else
                    {
                        x--;
                        y--;
                        down = false;
                        left = true;
                        i--;
                    }
                }
                else if (left)
                {
                    if (y > -1 && matrix[x, y] == '\0')
                    {
                        matrix[x, y] = (cont < text.Length) ? text[cont] : '#';
                        cont++;
                        y--;
                    }
                    else
                    {
                        y++;
                        x--;
                        left = false;
                        up = true;
                        i--;
                    }
                }
                else if (up)
                {
                    if (x > -1 && matrix[x, y] == '\0')
                    {
                        matrix[x, y] = (cont < text.Length) ? text[cont] : '#';
                        cont++;
                        x--;
                    }
                    else
                    {
                        y++;
                        x++;
                        up = false;
                        right = true;
                        i--;
                    }
                }
            }

            string outPut = "";
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    outPut += matrix[i, j];
                }
            }
            return outPut;
        }

        public string Decipher_Spiral()
        {
            int cont = 0;
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i, j] = text[cont];
                    cont++;
                }
            }

            string output = "";
            bool right = true, down = false, left = false, up = false;
            int x = 0, y = 0;
            for (int i = 0; i < m * n; i++)
            {
                if (right)
                {
                    if (y < n && matrix[x, y] != '\0')
                    {
                        output += matrix[x, y].ToString();
                        matrix[x, y] = '\0';
                        y++;
                    }
                    else
                    {
                        y--;
                        x++;
                        right = false;
                        down = true;
                        i--;
                    }
                }
                else if (down)
                {
                    if (x < m && matrix[x, y] != '\0')
                    {
                        output += matrix[x, y].ToString();
                        matrix[x, y] = '\0';
                        x++;
                    }
                    else
                    {
                        x--;
                        y--;
                        down = false;
                        left = true;
                        i--;
                    }
                }
                else if (left)
                {
                    if (y > -1 && matrix[x, y] != '\0')
                    {
                        output += matrix[x, y].ToString();
                        matrix[x, y] = '\0';
                        y--;
                    }
                    else
                    {
                        y++;
                        x--;
                        left = false;
                        up = true;
                        i--;
                    }
                }
                else if (up)
                {
                    if (x > -1 && matrix[x, y] != '\0')
                    {
                        output += matrix[x, y].ToString();
                        matrix[x, y] = '\0';
                        x--;
                    }
                    else
                    {
                        y++;
                        x++;
                        up = false;
                        right = true;
                        i--;
                    }
                }
            }
            return output;
        }
    }
}
