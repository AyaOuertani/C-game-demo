using Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class Board
    {
        readonly string[] grid = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public bool player1Turn = true;
        public int numTurns = 0;
        public Player player1;
        public Player player2;
        public delegate void WinEventHandler(string winner);
        public delegate void EndEventHandler();
        public event WinEventHandler WinEvent;
        public event EndEventHandler EndEvent;
        public Board(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public void PrintGrid()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grid[i * 3 + j] + "|");
                }
                Console.WriteLine("\n------");
            }
        }
        public bool Victory()
        {
            for (int i = 0; i <= 6; i += 3)
            {
                if (grid[i] == grid[i + 1] && grid[i + 1] == grid[i + 2])
                    return true;
            }
            for (int i = 0; i < 3; i++)
            {
                if (grid[i] == grid[i + 3] && grid[i + 3] == grid[i + 6])
                    return true;
            }

            if ((grid[0] == grid[4] && grid[4] == grid[8]) || (grid[2] == grid[4] && grid[4] == grid[6]))
                return true;

            return false;
        }

        public void PlayerChoice()
        {
            string choice = Console.ReadLine() ?? string.Empty;
            if (grid.Contains(choice))
            {
                int gridIndex = Convert.ToInt32(choice) - 1;

                if (grid[gridIndex] != "X" && grid[gridIndex] != "O")
                {
                    if (player1Turn)
                        grid[gridIndex] = "X";
                    else
                        grid[gridIndex] = "O";

                    numTurns++;
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
