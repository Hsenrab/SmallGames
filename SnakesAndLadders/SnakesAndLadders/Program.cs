using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {


        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int CurrentLocation { get; set;}
        public int Order { get; set; }
        public bool IsWinner { get; set; }

        public string TakeTurn(Board board, Die die)
        {
           
            int dieRoll = die.Roll();

            string message = "Name rolled a " + dieRoll.ToString() + "\n";
            int newLocation = CurrentLocation + dieRoll;

            if(newLocation > board.Spaces.Count)
            {
                IsWinner = true;
                message += "Name Wins!";
            }
            else if(board.Spaces[newLocation] > newLocation)
            {
                message += "Name lands on " + newLocation.ToString() + " and climbs up the ladder to "
                                            + board.Spaces[newLocation].ToString() + " !\n";
                CurrentLocation = board.Spaces[newLocation];
            }
            else if (board.Spaces[newLocation] < newLocation)
            {
                message += "Name lands on " + newLocation.ToString() + " and slides down the snake to "
                                            + board.Spaces[newLocation].ToString() + " !\n";
                CurrentLocation = board.Spaces[newLocation];
            }
            else
            {
                message += "Name lands on " + newLocation.ToString() + " .\n";
            }

            return message;
        }
    }

    public class Die
    {
        private Random rand;

        public Die()
        {
            rand = new Random();
        }

        public int Roll()
        {
            return rand.Next(1, 7);
        }
    }

    public class Board
    {
        // This list represents the board space at the given index, if this space triggers 
        // a snake/ladder the entry is the number of the destination square. Otherwise the
        // entry is -1.

        public List<int> Spaces { get; set; }
        public Board() 
        {
            Spaces = new List<int>();
            
            for(int i=0; i<25; i++)
            {
                Spaces.Add(-1);
            }

            // Add Ladders
            Spaces[1] = 8;
            Spaces[6] = 15;
            Spaces[11] = 20;

            // Add Snakes
            Spaces[7] = 3;
            Spaces[19] = 9;
            Spaces[22] = 16;
            Spaces[24] = 4;
        }
    }


}
