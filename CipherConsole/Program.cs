using System;
using Laboratorio_3_EDII.Manager;

namespace CipherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            

            
            Console.WriteLine("Cifrado de llave publica");
            Console.WriteLine("************************\n");
            Console.WriteLine("\b 1) Cifrado Cesar");
            Console.WriteLine("\b 2) Cifrado ZigZag");
            Console.WriteLine("\b 3) Cifrado Ruta Transpoción");
            Console.WriteLine("\b 4) Cifrado Ruta Espiral");
            Console.Write("\t Escoja una opción para cifrar: ");
            var OptionToCipher = Convert.ToInt16(Console.ReadLine());

            switch (OptionToCipher)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Cifrado Cesar");
                    Console.WriteLine("*************\n");
                    Console.Write("Ingrese la clave: ");
                    var Clave = Console.ReadLine();
                    Console.Write("\n Ingrese el texto a cifrar: ");
                    var TextToCipher = Console.ReadLine();
                    //Llamar el metodo
                    Console.WriteLine($"\n Texto cifrado es: {TextToCipher}");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Cifrado ZigZag");
                    Console.WriteLine("**************\n");
                    Console.Write("Ingrese la cantidad de filas: ");
                    var Row = Convert.ToInt16(Console.ReadLine());
                    Console.Write("\n \tIngrese el texto a cifrar: ");
                    var TextToCipher2 = Console.ReadLine();
                    //Llamar el metodo
                    Console.WriteLine($"\n Texto cifrado es: {TextToCipher2}");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Cifrado Ruta por Transpoción");
                    Console.WriteLine("****************************\n");
                    Console.Write("Ingrese la cantidad de filas: ");
                    var Row2 = Convert.ToInt16(Console.ReadLine());
                    Console.Write("\nIngrese la cantidad de columnas: ");
                    var Column2 = Convert.ToInt16(Console.ReadLine());
                    Console.Write("\n \b Ingrese el texto a cifrar: ");
                    var TextToCipher3 = Console.ReadLine();
                    //Llamar el metodo
                    Console.WriteLine($"\n \b Texto cifrado es: {TextToCipher3}");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Cifrado Ruta en espiral");
                    Console.WriteLine("****************************\n");
                    Console.Write("Ingrese la cantidad de filas: ");
                    var Row3 = Convert.ToInt16(Console.ReadLine());
                    Console.Write("\nIngrese la cantidad de columnas: ");
                    var Column3 = Convert.ToInt16(Console.ReadLine());
                    Console.Write("\n \b Ingrese el texto a cifrar: ");
                    var TextToCipher4 = Console.ReadLine();
                    //Llamar el metodo
                    Console.WriteLine($"\n \b Texto cifrado es: {TextToCipher4}");
                    Console.ReadKey();
                    break;
            }

        }
    }
}
