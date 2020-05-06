using System;

namespace TicTacToe
{
    public class DrawBoard
    {
        public DrawBoard(){
            this.Places = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            this.QueringPlace  = true;
        }
        public string[] Places { get; set; }
        public bool QueringPlace { get; set; }
        public string Selection { get; set; }

        internal void showBoard()
        {   
            //Draw the board. iterate +3 cause everyline has 3 places
            //dont knew how to do with i++
            for (int i = 0; i < 7; i+=3) 
            {
                Console.WriteLine("-----");
                Console.WriteLine(Places[i] + "|" + Places[i + 1] + "|" + Places[i + 2]);
            }
            Console.WriteLine("-----");
        }

    }
}