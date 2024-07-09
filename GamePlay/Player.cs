using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Play
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Player(string name = "", int score = 0)
        {
            Name = name;
            Score = score;
        }

        public void DisplayPlayerScore(int playerNumbr)
        {
            Console.WriteLine($"\nPlayer{playerNumbr} : {Name}                Score: {Score}");
        }
        public void DisplayAndSaveHigherScore(Player player)
        {
            Console.WriteLine($"\nPlayer Higher : {Name}                Score: {Score}");
            ConsoleApp1.Play.Score.SaveHighScore(player);
        }
    }
}
