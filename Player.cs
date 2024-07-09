using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameScore;
namespace ConsoleApp1
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

        public void DisplayPlayerScore (int PlayerNumbr) {
            Console.WriteLine($"\nPlayer{PlayerNumbr} : {Name}                Score: {Score}");
        }
        public void DisplayAndSaveHigherScore(Player player)
        {
            Console.WriteLine($"\nPlayer Higher : {Name}                Score: {Score}");
            GameScore.Score.SaveHighScore(player);
        }
    }
}
