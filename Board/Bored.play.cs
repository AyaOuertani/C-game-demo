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
        public void Play(Player player1, Player player2, string mode)
        {
            while (!Victory() && NumTurns != 9)
            {
                PrintGrid();
                if (Player1Turn)
                {
                    Console.WriteLine("Player 1 Turn!");
                    PlayerChoice();
                }
                else
                {
                    Console.WriteLine("Player 2 Turn!");
                    if (mode == "vsComputer")
                    {
                        ComputerPlayer.PlayerChoice(Grid, ref NumTurns);
                    }
                    else
                        PlayerChoice();
                }
                Player1Turn = !Player1Turn;
            }
            PrintGrid();
            if (Victory())
            {
                if (!Player1Turn)
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
