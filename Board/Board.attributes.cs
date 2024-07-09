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
        readonly string[] Grid = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public bool Player1Turn = true;
        public int NumTurns = 0;
        public Player Player1;
        public Player Player2;
        public delegate void WinEventHandler(string winner);
        public delegate void EndEventHandler();
        public event WinEventHandler WinEvent;
        public event EndEventHandler EndEvent;
    }
}
