using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
using ConsoleApp1;
namespace Computer
{
    public partial class ComputerPlayer
    {
        public static partial void PlayerChoice(string[] grid, ref int numTurns)
        {
            int moveIndex = FindWinningMove(grid);

            if (moveIndex == -1)
            {
                moveIndex = BlockOpponentWin(grid);
            }
            if (moveIndex == -1)
            {
                Random random = new Random();
                do
                {
                    moveIndex = random.Next(0, 9);
                } while (grid[moveIndex] == "X" || grid[moveIndex] == "O");
            }
            grid[moveIndex] = "O";
            numTurns++;
        }
    }
}
