using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Cipher
{
    public class Route
    {
        public byte[] CipherSpiral(byte[] Text, int Rows, int Columns)
        {

            byte[,] Cipher = new byte[Rows, Columns];
            var X = 0;
            var Y = 0;
            var RangeXo = 0;
            var RangeXf = Columns - 1;
            var RangeYo = 0;
            var RangeYf = Rows - 1;
            var cont = 0;
            var SizeToArray = (Rows * Columns);
            var Direction = "Right";
            while (cont < SizeToArray)
            {
                switch (Direction)
                {
                    case "Right":
                        while ((X >= RangeXo) && (X <= RangeXf))
                        {
                            if (cont < Text.Length)
                            {
                                Cipher[Y, X] = Text[cont];
                                if (X < RangeXf) { X++; }
                                else { cont++; break; }
                            }
                            else if (cont >= Text.Length)
                            {
                                Cipher[Y, X] = (byte)'$';
                                if (X < RangeXf) { X++; }
                                else { cont++; break; }
                            }
                            cont++;
                        }
                        Direction = "Down";
                        RangeYo++;
                        Y = RangeYo;
                        break;
                    case "Down":
                        while ((Y >= RangeYo) && (Y <= RangeYf))
                        {
                            if (cont < Text.Length)
                            {
                                Cipher[Y, X] = Text[cont];
                                if (Y < RangeYf) { Y++; }
                                else { cont++; break; }
                            }
                            else if (cont >= Text.Length)
                            {
                                Cipher[Y, X] = (byte)'$';
                                if (Y < RangeYf) { Y++; }
                                else { cont++; break; }
                            }
                            cont++;
                        }
                        Direction = "Left";
                        RangeXf--;
                        X = RangeXf;
                        break;
                    case "Left":
                        while ((X >= RangeXo) && (X <= RangeXf))
                        {
                            if (cont < Text.Length)
                            {

                                Cipher[Y, X] = Text[cont];
                                if (X > RangeXo) { X--; }
                                else { cont++; break; }
                            }
                            if (cont >= Text.Length)
                            {

                                Cipher[Y, X] = (byte)'$';
                                if (X > RangeXo) { X--; }
                                else { cont++; break; }
                            }
                            cont++;
                        }
                        Direction = "Up";
                        RangeYf--;
                        Y = RangeYf;
                        break;
                    case "Up":
                        while ((Y >= RangeYo) && (Y <= RangeYf))
                        {
                            if (cont < Text.Length)
                            {
                                Cipher[Y, X] = Text[cont];
                                if (Y > RangeYo) { Y--; }
                                else { cont++; break; }
                            }
                            if (cont >= Text.Length)
                            {
                                Cipher[Y, X] = (byte)'$';
                                if (Y > RangeYo) { Y--; }
                                else { cont++; break; }
                            }
                            cont++;
                        }
                        Direction = "Right";
                        RangeXo++;
                        X = RangeXo;
                        break;
                }
            }

            byte[] bytes = new byte[SizeToArray];
            var contador = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    bytes[contador] = Cipher[i, j];
                    contador++;
                }
            }
           

            return bytes; 
        }

        public byte[] DescipherSpiral(byte[] Text, int Rows, int Columns)
        {
            
            byte[,] Decipher = new byte[Rows, Columns];
            var X = 0;
            var Y = 0;
            var RangeXo = 0;
            var RangeXf = Columns - 1;
            var RangeYo = 0;
            var RangeYf = Rows - 1;
            var cont1 = 0;
            var cont = 0;
            var SizeToArray = (Rows * Columns);
            var Direction = "Right";
            byte[] bytes = new byte[SizeToArray];


            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Decipher[i, j] = Text[cont1];
                    cont1++;
                }
            }

            while (cont < SizeToArray)
            {
                switch (Direction)
                {
                    case "Right":
                        while ((X >= RangeXo) && (X <= RangeXf))
                        {
                            if (cont < Text.Length)
                            {
                                bytes[cont] = Decipher[Y, X];
                                if (X < RangeXf) { X++; }
                                else { cont++; break; }
                            }
                            else if (cont >= Text.Length)
                            {
                                bytes[cont] = Decipher[Y, X];
                                if (X < RangeXf) { X++; }
                                else { cont++; break; }
                            }
                            cont++;
                        }
                        Direction = "Down";
                        RangeYo++;
                        Y = RangeYo;
                        break;
                    case "Down":
                        while ((Y >= RangeYo) && (Y <= RangeYf))
                        {
                            if (cont < Text.Length)
                            {
                                bytes[cont] = Decipher[Y, X];
                                if (Y < RangeYf) { Y++; }
                                else { cont++; break; }
                            }
                            else if (cont >= Text.Length)
                            {
                                bytes[cont] = Decipher[Y, X];
                                if (Y < RangeYf) { Y++; }
                                else { cont++; break; }
                            }
                            cont++;
                        }
                        Direction = "Left";
                        RangeXf--;
                        X = RangeXf;
                        break;
                    case "Left":
                        while ((X >= RangeXo) && (X <= RangeXf))
                        {
                            if (cont < Text.Length)
                            {

                                bytes[cont] = Decipher[Y, X];
                                if (X > RangeXo) { X--; }
                                else { cont++; break; }
                            }
                            if (cont >= Text.Length)
                            {

                                bytes[cont] = Decipher[Y, X];
                                if (X > RangeXo) { X--; }
                                else { cont++; break; }
                            }
                            cont++;
                        }
                        Direction = "Up";
                        RangeYf--;
                        Y = RangeYf;
                        break;
                    case "Up":
                        while ((Y >= RangeYo) && (Y <= RangeYf))
                        {
                            if (cont < Text.Length)
                            {
                                bytes[cont] = Decipher[Y, X];
                                if (Y > RangeYo) { Y--; }
                                else { cont++; break; }
                            }
                            if (cont >= Text.Length)
                            {
                                bytes[cont] = Decipher[Y, X];
                                if (Y > RangeYo) { Y--; }
                                else { cont++; break; }
                            }
                            cont++;
                        }
                        Direction = "Right";
                        RangeXo++;
                        X = RangeXo;
                        break;
                }
            }
            return bytes;
        }

        public string Cipher(byte[] Text, int Rows, int columns)
        {
            var Result1 = "";
            List<byte[]> list = new List<byte[]>();
            var SizeToArray = (Rows * columns);
            if (Text.Length < SizeToArray) { CipherSpiral(Text, Rows, columns); }
            else
            {
                var contador = 0;
                while(contador < Text.Length)
                {
                    byte[] bytes = new byte[SizeToArray];
                    for (int i = 0; i < SizeToArray; i++)
                    {
                        if (contador < Text.Length) { bytes[i] = Text[contador]; contador++; }
                        else { bytes[i] = (byte)'$'; contador++; }
                    }
                    var Result  = CipherSpiral(bytes, Rows, columns);
                    list.Add(Result);
                }
            }
            foreach (var item in list)
            {
                Result1 += Encoding.ASCII.GetString(item);
            }

            return Result1;
        }

        public string Decipher(byte[] Text, int Rows, int columns)
        {
            var Result1 = "";
            List<byte[]> list = new List<byte[]>();
            var SizeToArray = (Rows * columns);
            if (Text.Length < SizeToArray) { CipherSpiral(Text, Rows, columns); }
            else
            {
                var contador = 0;
                while (contador < Text.Length)
                {
                    byte[] bytes = new byte[SizeToArray];
                    for (int i = 0; i < SizeToArray; i++)
                    {
                        if (contador < Text.Length) { bytes[i] = Text[contador]; contador++; }
                        else { bytes[i] = (byte)'$'; contador++; }
                    }
                    var Result = DescipherSpiral(bytes, Rows, columns);
                    list.Add(Result);
                }
            }
            foreach (var item in list)
            {
                Result1 += Encoding.ASCII.GetString(item);
            }

            return Result1;
        }
    }

}
