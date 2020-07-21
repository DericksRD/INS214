using System;
using System.IO;

namespace Programa_fina
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("input.csv");
            for(int i = 1; i < text.Length; i++){
                Info data = new Info(text[i]);
                File.AppendAllText("output.csv","\n" + data.DateAndTime + "," + data.Weather);
                Console.WriteLine("Información almacenada exitosamente!");
            }
        }
    }
}
