namespace OperacoesFilas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //pode ser um input do usuario
            int numeroDeJogadores = 10; //(onde altera)
            JogoBatataQuente(numeroDeJogadores);
        }
        public static void JogoBatataQuente(int numeroDeJogadores)
        {           
            Queue<int> jogadores = new Queue<int>();
            for (int i = 1; i <= numeroDeJogadores; i++)
            {
                jogadores.Enqueue(i);
                //1,2,3,4,5,6,7,8,9,10
            }
            
            Random random = new Random();
            int passesParaExplodir = random.Next(1, 101);

            
            while (jogadores.Count > 1)
            {                
                for (int i = 1; i < passesParaExplodir; i++)
                {                 
                    int jogadorAtual = jogadores.Dequeue(); //atualiza a fila
                    jogadores.Enqueue(jogadorAtual);
                }
                jogadores.Dequeue(); //remove o jogador que explodiu
            }
         
            int jogadorVencedor = jogadores.Dequeue();
            Console.WriteLine($"O jogador número {jogadorVencedor} é o vencedor!");
        }

    }
}
