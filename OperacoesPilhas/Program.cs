

namespace OperacoesPilhas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expressaoBalanceada = "(2+1)*80/(7-[√9 + {4² * 0}])";
            string expressaoNaoBalanceada = "([{35 - 2} + 5*3} + 0 / 15) - [3 + 5³] * 11)";

            Console.WriteLine("Expressão balanceada: " + VerificarBalanceamentoExpressao(expressaoBalanceada));
            Console.WriteLine("Expressão não balanceada: " + VerificarBalanceamentoExpressao(expressaoNaoBalanceada));
        }
        public static bool VerificarBalanceamentoExpressao(string expressao)
        {
            Stack<char> pilha = new Stack<char>();

            foreach (char caractere in expressao)
            {
                switch (caractere)
                {
                    case '(':
                    case '[':
                    case '{':
                        pilha.Push(caractere);
                        break;
                    case ')':
                    case ']':
                    case '}':
                        if (pilha.Count == 0)
                            return false;

                        char caractereAbertura = pilha.Pop();
                        if (!ParDeParentesesCorrespondente(caractereAbertura, caractere))
                            return false;
                        break;
                    default:
                        
                        break;
                }
            }            
            return pilha.Count == 0;
        }

        public static bool ParDeParentesesCorrespondente(char caractereAbertura, char caractereFechamento)
        {
            return (caractereAbertura == '(' && caractereFechamento == ')') ||
                   (caractereAbertura == '[' && caractereFechamento == ']') ||
                   (caractereAbertura == '{' && caractereFechamento == '}');
        }
    }
}

