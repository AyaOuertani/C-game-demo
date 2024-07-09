using Computer;
using ConsoleApp1.Play;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class Board
    {
        public Board(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        public void PrintGrid()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Grid[i * 3 + j] + "|");
                }
                Console.WriteLine("\n------");
            }
        }
        public bool Victory()
        {
            for (int i = 0; i <= 6; i += 3)
            {
                if (Grid[i] == Grid[i + 1] && Grid[i + 1] == Grid[i + 2])
                    return true;
            }
            for (int i = 0; i < 3; i++)
            {
                if (Grid[i] == Grid[i + 3] && Grid[i + 3] == Grid[i + 6])
                    return true;
            }

            if ((Grid[0] == Grid[4] && Grid[4] == Grid[8]) || (Grid[2] == Grid[4] && Grid[4] == Grid[6]))
                return true;

            return false;
        }
        public void PlayerChoice()
        {
            string choice = Console.ReadLine() ?? string.Empty;
            if (Grid.Contains(choice))
            {
                int gridIndex = Convert.ToInt32(choice) - 1;

                if (Grid[gridIndex] != "X" && Grid[gridIndex] != "O")
                {
                    if (Player1Turn)
                        Grid[gridIndex] = "X";
                    else
                        Grid[gridIndex] = "O";

                    NumTurns++;
                }
                else
                {
                    Console.WriteLine("Spot already taken. Try again.");
                    PlayerChoice();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
                PlayerChoice();
            }
        }

    }

}
