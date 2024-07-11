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
    }
}
