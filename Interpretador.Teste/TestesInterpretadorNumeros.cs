using Interpretador.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interpretador.Teste
{
    [TestClass]
    public class TestesInterpretadorNumeros
    {
        [TestMethod]
        [DataRow("Um centavo de real", 0.01)]
        [DataRow("Cinco centavos de real", 0.05)]
        [DataRow("Vinte e cinco centavos de real", 0.25)]
        public void DeveVerificarCentavos(string resultadoCorretoExt, double numero)
        {           
            InterpretadorNumeros interpretador = new InterpretadorNumeros();

            string numeroTraduzidoParaExt = interpretador.ConverterNumeroParaExt(numero);

            Assert.AreEqual(resultadoCorretoExt, numeroTraduzidoParaExt);
        }

        [TestMethod]
        [DataRow("Dois reais e vinte e cinco centavos", 2.25)]
        [DataRow("Quinze mil quatrocentos e quinze reais e dezesseis centavos", 15415.16)]        
        [DataRow("Sete reais e noventa e nove centavos", 7.99)]
        [DataRow("Trinta e sete reais e trinta e dois centavos", 37.32)]
        [DataRow("Seiscentos e trinta e sete reais e quinze centavos", 637.15)]
        [DataRow("Mil seiscentos e trinta e sete reais e onze centavos", 1637.11)]
        [DataRow("Sessenta e um mil seiscentos e trinta e sete reais e dez centavos", 61637.10)]
        [DataRow("Novecentos e sessenta e um mil seiscentos e trinta e sete reais e vinte e nove centavos", 961637.29)]
        [DataRow("Um milhão oitocentos e cinquenta e dois mil e setecentos reais e vinte e um centavos", 1852700.21)]
        [DataRow("Cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais e dezenove centavos", 5961637.19)]
        [DataRow("Vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais e oitenta e um centavos", 25961637.81)]
        [DataRow("Quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais e oitenta e nove centavos", 425961637.89)]
        [DataRow("Oito bilhões quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais e noventa e oito centavos", 8425961637.98)]
        public void DeveVerificarCentavosReais(string resultadoCorretoExt, double numero)
        {
            InterpretadorNumeros interpretador = new InterpretadorNumeros();

            string numeroTraduzidoParaExt = interpretador.ConverterNumeroParaExt(numero);

            Assert.AreEqual(resultadoCorretoExt, numeroTraduzidoParaExt);
        }

        [TestMethod]
        [DataRow("Sete reais", 7.00)]
        [DataRow("Trinta e sete reais", 37.00)]
        [DataRow("Seiscentos e trinta e sete reais", 637.00)]
        [DataRow("Mil seiscentos e trinta e sete reais", 1637.00)]
        [DataRow("Sessenta e um mil seiscentos e trinta e sete reais", 61637.00)]
        [DataRow("Novecentos e sessenta e um mil seiscentos e trinta e sete reais", 961637.00)]
        [DataRow("Um milhão oitocentos e cinquenta e dois mil e setecentos reais", 1852700.00)]
        [DataRow("Cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", 5961637.00)]
        [DataRow("Vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", 25961637.00)]
        [DataRow("Quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", 425961637.00)]
        [DataRow("Oito bilhões quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", 8425961637.00)]
        public void DeveVerificarReais(string resultadoCorretoExt, double numero)
        {
            InterpretadorNumeros interpretador = new InterpretadorNumeros();

            string numeroTraduzidoParaExt = interpretador.ConverterNumeroParaExt(numero);

            Assert.AreEqual(resultadoCorretoExt, numeroTraduzidoParaExt);
        }  

    }
}
