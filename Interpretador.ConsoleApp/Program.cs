using System;

namespace Interpretador.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InterpretadorNumeros inter = new InterpretadorNumeros();

            string aux = inter.ConverterNumeroParaExt(15415.16);
        }
    }
}
