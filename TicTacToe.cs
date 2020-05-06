using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Program
    {
        static protected string selection;
        static protected int selectionPlace;
        static protected int counter = 0;
        static protected String currentCharPlayer;
        static protected string howWon;
        
        
        static void Main(string[] args)
        {
            //Green text for a old school look haha
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            //instance the board and player classes
            DrawBoard drawBoard = new DrawBoard();
            PlayersAndChar player = new PlayersAndChar();

            greetings();
            //query do nome dos players
            player.askNames();


            // ramdomize how start
            Random random = new Random();
            string playerRound = random.Next(2) == 0 ? player.Player1 : player.Player2;
            currentCharPlayer = playerRound == player.Player1 ? player.player1char : player.player2char;
            
        
            Console.WriteLine(playerRound + " foi escolhido de forma aleatória para começar!");


            // draw the board

            while (winner(drawBoard.Places) == false && counter < 9)
            {
                drawBoard.showBoard();
                Console.WriteLine("");
                Console.WriteLine("Faça sua jogada " + playerRound);

                while (true)
                {
                    selection = Console.ReadLine();
                    
                    if (!Regex.IsMatch(selection, @"\d"))
                    {
                        Console.WriteLine("Entrada Invalida! Escolha um numero de 1 a 9");
                        continue;
                    }
                    selectionPlace = int.Parse(selection) - 1;
                    if (drawBoard.Places[selectionPlace] == "X" || drawBoard.Places[selectionPlace] == "O")
                    {
                        Console.WriteLine("Entrada Invalida! Escolha um quadrante que ainda não foi escolhido");
                    }
                    else
                    {
                        drawBoard.Places[selectionPlace] = currentCharPlayer;

                        if (currentCharPlayer == player.player1char)
                        {
                            currentCharPlayer = player.player2char;
                            playerRound = player.Player2;
                        }
                        else
                        {
                            currentCharPlayer = player.player1char;
                            playerRound = player.Player1;
                        }
                        break;
                    }
                }
                Console.WriteLine("");
                counter++;

            }
            // invert howWon == last player to play wich is != playerRound
            howWon = playerRound == player.Player1 ? player.Player2 : player.Player1;
            Console.Clear();
            drawBoard.showBoard();
            if (winner(drawBoard.Places))
            {
                congratulations(howWon);
            }
            else
            {
                everyOneLoses();
            }
        }



        static void greetings()
        {
            Console.Title = "Trabalho de POO - Jogo da Velha";
            Console.WriteLine("VAMOS JOGAR UM JOGO?");
            Console.WriteLine("");
            Console.WriteLine("Seja bem-vindo ao meu trabalho de Poo, ele consiste deum simples jogo da velha");
            Console.WriteLine("");
            Console.WriteLine("Me chamo Jean Felipe Sorio e com prazer lhe apresento esse jogo!");
            Console.WriteLine("");
            Console.WriteLine("Siga no github: @JeanFSorio");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pressiona qualquer tecla para começar");
            Console.ReadKey();
            Console.Clear();
            
        }
        static Boolean winner(string[] board)
        {
            // check lines
            for (int i = 0; i < 7; i += 3)
            {
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2])
                {
                    return true;
                }
            }
            // check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
                {
                    return true;
                }
            }


            // check diagonal
            if (board[2].Equals(board[4]) && board[4].Equals(board[6]))
                return true;
            if (board[0].Equals(board[4]) && board[4].Equals(board[8]))
                return true;


            return false;
        }
        static void congratulations(string winner)
        {
            Console.WriteLine("");
            Console.WriteLine("Parabens " + winner + "! Você jogou muito bem!");
            Console.WriteLine("");
            Console.WriteLine("Tecle ENTER para sair");
            Console.ReadLine();
        }
        static void everyOneLoses()
        {
            Console.WriteLine("");
            Console.WriteLine("É um empate!! Todos jogaram muito bem,estão no mesmo nivel!");
            Console.WriteLine("");
            Console.WriteLine("Tecle ENTER para sair");
            Console.ReadLine();
        }

    }
}