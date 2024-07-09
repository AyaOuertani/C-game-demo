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
        public void Play(Player player1, Player player2, string mode)
        {
            while (!Victory() && numTurns != 9)
            {
                PrintGrid();
                if (player1Turn)
                {
                    Console.WriteLine("Player 1 Turn!");
                    PlayerChoice();
                }
                else
                {
                    Console.WriteLine("Player 2 Turn!");
                    if (mode == "vsComputer")
                    {
                        ComputerPlayer.PlayerChoice(grid, ref numTurns);
                    }
                    else
                        PlayerChoice();
                }
                player1Turn = !player1Turn;
            }
            PrintGrid();
            if (Victory())
            {
                if (!player1Turn)
                {
                    WinEvent.Invoke(player1.Name);
                    player1.Score += 10;
                }
                else
                {
                    WinEvent.Invoke(player2.Name);
                    player2.Score += 10;
                }
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }
    }
}
