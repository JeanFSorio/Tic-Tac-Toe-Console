using System;

namespace TicTacToe
{
    public class Players
    {
        public string Player1 {get; set;}
        public string Player2 {get; set;}
    }
    public class PlayersAndChar : Players
    {

        public PlayersAndChar()
        {
            this.player1char = "X";
            this.player2char = "O";
        }
        public string player1char { get; set; }
        public string player2char { get; set; }
        internal void askNames()
        {
            Console.WriteLine("Escreva o nome do jogador 1 e de enter");
            Player1 = Console.ReadLine();
            if (Player1 == "")
            {
                Player1 = "Jogador X";
            }
            Console.WriteLine(Player1 + " seu simbolo será o " + player1char);
            Console.WriteLine("");
            Console.WriteLine("Escreva o nome do jogador 2 e de enter");
            Player2 = Console.ReadLine();
            if (Player2 == "")
            {
                Player2 = "Jogador O";
            }
            Console.WriteLine(Player2 + " seu simbolo será " + player2char);
            Console.WriteLine("");
            Console.WriteLine("Pressione ENTER quando pronto");
            Console.ReadKey();
            Console.Clear();



        }

    }
}