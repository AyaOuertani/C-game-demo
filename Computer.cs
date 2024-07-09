using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
using ConsoleApp1;

namespace Computer
{
    public partial  class ComputerPlayer : Player
    {
        public ComputerPlayer (string name = "", int score = 0) : base(score = 0) {

            this.name = "Computer";
        }
        private static int FindWinningMove(string[] grid)
        {
            for (int i = 0; i <= 6; i += 3)
            {
                if (grid[i] == "O" && grid[i + 1] == "O" && grid[i + 2] != "X")
                    return i + 2;
                if (grid[i] == "O" && grid[i + 1] != "X" && grid[i + 2] == "O")
                    return i + 1;
                if (grid[i] != "X" && grid[i + 1] == "O" && grid[i + 2] == "O")
                    return i;
            }
            for (int i = 0; i < 3; i++)
            {
                if (grid[i] == "O" && grid[i + 3] == "O" && grid[i + 6] != "X")
                    return i + 6;
                if (grid[i] == "O" && grid[i + 3] != "X" && grid[i + 6] == "O")
                    return i + 3;
                if (grid[i] != "X" && grid[i + 3] == "O" && grid[i + 6] == "O")
                    return i;
            }
            if (grid[0] == "O" && grid[4] == "O" && grid[8] != "X")
                return 8;
            if (grid[0] == "O" && grid[4] != "X" && grid[8] == "O")
                return 4;
            if (grid[0] != "X" && grid[4] == "O" && grid[8] == "O")
                return 0;
            if (grid[2] == "O" && grid[4] == "O" && grid[6] != "X")
                return 6;
            if (grid[2] == "O" && grid[4] != "X" && grid[6] == "O")
                return 4;
            if (grid[2] != "X" && grid[4] == "O" && grid[6] == "O")
                return 2;

            return -1;
        }

        private static int BlockOpponentWin(string[] grid)
        {
            for (int i = 0; i <= 6; i += 3)
            {
                if (grid[i] == "X" && grid[i + 1] == "X" && grid[i + 2] != "O")
                    return i + 2;
                if (grid[i] == "X" && grid[i + 1] != "O" && grid[i + 2] == "X")
                    return i + 1;
                if (grid[i] != "O" && grid[i + 1] == "X" && grid[i + 2] == "X")
                    return i;
            }

            for (int i = 0; i < 3; i++)
            {
                if (grid[i] == "X" && grid[i + 3] == "X" && grid[i + 6] != "O")
                    return i + 6;
                if (grid[i] == "X" && grid[i + 3] != "O" && grid[i + 6] == "X")
                    return i + 3;
                if (grid[i] != "O" && grid[i + 3] == "X" && grid[i + 6] == "X")
                    return i;
            }
            if (grid[0] == "X" && grid[4] == "X" && grid[8] != "O")
                return 8;
            if (grid[0] == "X" && grid[4] != "O" && grid[8] == "X")
                return 4;
            if (grid[0] != "O" && grid[4] == "X" && grid[8] == "X")
                return 0;

            if (grid[2] == "X" && grid[4] == "X" && grid[6] != "O")
                return 6;
            if (grid[2] == "X" && grid[4] != "O" && grid[6] == "X")
                return 4;
            if (grid[2] != "O" && grid[4] == "X" && grid[6] == "X")
                return 2;

            return -1;
        }
        public static partial void PlayerChoice(string[] grid, ref int numTurns);

    }
}