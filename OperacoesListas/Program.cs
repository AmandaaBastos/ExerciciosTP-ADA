using System;

namespace OperacoesListas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<string>{
              "Idiossincrasia",
              "Ambivalente",
              "Quimérica",
              "Perpendicular",
              "Efêmero",
              "Pletora",
              "Obnubilado",
              "Xilografia",
              "Quixote",
              "Inefável"
            };

            foreach (var palavra in FiltrarTamanho(lista, 10))
            {
                Console.WriteLine(palavra);
            }

        }

        static IEnumerable<string> FiltrarTamanho(List<string> lista, int tamanho)
        {

            foreach (var palavra in lista)
            {
                if (palavra.Length >= tamanho)
                {
                    yield return palavra;
                }

            }
        }
    }
}
