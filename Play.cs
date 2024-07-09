using Computer;
using GameScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Play
    {
        public bool res { get; set; } = true;
        public string mode { get; set; }
       
        public  void PlayersCreation(out Player player1)
        {
            Console.Write("Player Name: ");
            string playerName = Console.ReadLine() ?? string.Empty;
            player1 = new Player(playerName);
        }
        public void Display(Player player1, Player player2, Player HighPlayer, string mode)
        {
            HighPlayer = Score.CheckHighScore(player1, player2, HighPlayer, mode);
            player1.DisplayPlayerScore(1);
            player2.DisplayPlayerScore(2);
            HighPlayer.DisplayAndSaveHigherScore(HighPlayer);

        }
        public  bool Restart(bool res)
        {
            Console.Write("Do you want to play another round ?: (yes/no) :");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
                return true;
            else
            {
                HandleEndEvent();
                return false;
            }

        }
        public void HandleWinEvent(string winner)
        {
            Console.WriteLine($"Congratulations, {winner} wins!");
        }
        public  void HandleEndEvent()
        {
            Console.WriteLine("Good Game! See Ya Next Time! ");

        }
    }
}
