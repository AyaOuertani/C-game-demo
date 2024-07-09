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
    }
}
