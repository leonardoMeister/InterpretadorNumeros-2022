using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Interpretador.ConsoleApp
{
    public class InterpretadorNumeros : DicionarioNumeros
    {
        public string ConverterNumeroParaExt(double numero)
        {
            return DeixarAPrimeiraLetraMaiuscula(Parse(numero));
        }

        private string Parse(double n)
        {
            List<string> saida = new List<string>();

            int centavos = PegarCentavos(n);
            long reais = PegarReais(n);

            if (reais != 0)
                saida.Add(ConverterReaisParaExtenso(reais));

            if (centavos != 0)
                saida.Add(ConverterCentavosParaExtenso(centavos, NaoTemParteReal(reais)));

            string numeroExtenso = AdicionandoLigadura(saida, "e");
            return numeroExtenso;
        }
        private long PegarReais(double n)
        {
            return (long)Math.Truncate(n);
        }
        private int PegarCentavos(double n)
        {
            // https://stackoverflow.com/a/28848788
            string str = n.ToString("0.00", CultureInfo.InvariantCulture);
            return Convert.ToInt32(str.Substring(str.IndexOf('.') + 1));
        }
        private string ConverterCentavosParaExtenso(int centavos, bool temApenasCentavos)
        {
            if (centavos == 0) return "";

            string saida = "";

            saida += ConverterCentenaParaExtenso(centavos);
            saida += " ";

            saida += (centavos == 1) ? "centavo" : "centavos";

            if (temApenasCentavos) saida += " de real";

            return saida;
        }
        private string ConverterReaisParaExtenso(long reais)
        {
            List<string> saida = new List<string>();
            int unidadeDeMilharAtual = 0;

            saida.Add((reais == 1) ? "real" : "reais");

            while (reais != 0)
            {
                long centena = reais % 1000;
                reais /= 1000;
                unidadeDeMilharAtual++;

                if (centena == 1)
                    saida.Add(unidadesDeMilharSingular[unidadeDeMilharAtual]);

                else if (centena != 0)
                    saida.Add(unidadesDeMilharPlural[unidadeDeMilharAtual]);

                if (NaoEh1mil(unidadeDeMilharAtual, centena))
                    saida.Add(ConverterCentenaParaExtenso(centena));

                if (DeveColocarLigadura(reais, unidadeDeMilharAtual, centena))
                    saida.Add("e");
            }
            saida.Reverse();
            return AdicionandoLigadura(saida, "");
        }
        private string ConverterCentenaParaExtenso(long n)
        {
            if (n == 0)
                return "";

            if (n == 100)
                return "cem";

            int contador = 0;
            List<string> saida = new List<string>();

            long dezena = n % 100;

            if (DezenaEstaEntre10e20(dezena))
            {
                saida.Add(dezenasExt[dezena]);
                n /= 100;
                contador = 2;
            }

            while (n != 0)
            {
                long unidade = n % 10;
                n /= 10;
                contador++;

                if (unidade == 0)
                    continue;

                saida.Add(dicionariosPorUnidadeDeCentena[contador][unidade]);
            }
            saida.Reverse();
            return AdicionandoLigadura(saida, "e");
        }
        private string AdicionandoLigadura(List<string> lista, string ligadura)
        {
            string saida = "";
            string ligaduraUsada;

            if (ligadura == "") ligaduraUsada = " "; else ligaduraUsada = $" {ligadura} ";

            int contador = 0;
            while (lista.Count != (contador))
            {
                string str = lista[contador];

                if (string.IsNullOrEmpty(str)) { contador++; continue; }

                saida += str;

                if (lista.Count != 0 && (lista.Count != (contador) + 1)) saida += ligaduraUsada;

                contador++;
            }

            return saida;
        }
        private string DeixarAPrimeiraLetraMaiuscula(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
        private bool NaoTemParteReal(long reais)
        {
            return reais == 0;
        }
        private bool NaoEh1mil(int contador, long centena)
        {
            return centena != 1 || contador != 2;
        }
        private bool DeveColocarLigadura(long reais, int contador, long centena)
        {
            return contador == 1 && (centena % 100 == 0 || centena < 100) && reais != 0;
        }
        private bool DezenaEstaEntre10e20(long dezena)
        {
            return dezena >= 10 && dezena < 20;
        }
    }
}
