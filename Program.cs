using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.IO;
using System.Linq;
using System.Reflection;
using Computer;
using Score;
using System.ComponentModel;
using static System.Formats.Asn1.AsnWriter;

namespace Game
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
    public class Board
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
        public Board(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void PrintGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grid[i * 3 + j] + "|");
                }
                Console.WriteLine("\n------");
            }
        }
        public bool Victory()
        {
            for (int i = 0; i <= 6; i += 3)
            {
                if (grid[i] == grid[i + 1] && grid[i + 1] == grid[i + 2])
                    return true;
            }
            for (int i = 0; i < 3; i++)
            {
                if (grid[i] == grid[i + 3] && grid[i + 3] == grid[i + 6])
                    return true;
            }

            if ((grid[0] == grid[4] && grid[4] == grid[8]) || (grid[2] == grid[4] && grid[4] == grid[6]))
                return true;

            return false;
        }

        public void PlayerChoice()
        {
            string choice = Console.ReadLine() ?? string.Empty;
            if (grid.Contains(choice))
            {
                int gridIndex = Convert.ToInt32(choice) - 1;

                if (grid[gridIndex] != "X" && grid[gridIndex] != "O")
                {
                    if (player1Turn)
                        grid[gridIndex] = "X";
                    else
                        grid[gridIndex] = "O";

                    numTurns++;
                }
                else
                {
                    Console.WriteLine("Spot already taken. Try again.");
                    PlayerChoice();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
                PlayerChoice();
            }
        }
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

        public static class Program
        {
            public static void PlayersCreation(out Player player1, out Player player2, string mode)
            {
                Console.Write("Player1 Name: ");
                string playerName = Console.ReadLine() ?? string.Empty;
                player1 = new Player(playerName);
                if (mode == "vsComputer")
                {
                    player2 = new Player("Computer");
                }
                else
                {
                    Console.Write("Player 2 Name: ");
                    playerName = Console.ReadLine() ?? string.Empty;
                    player2 = new Player(playerName);
                }
            }
            public static void Display(Player player1, Player player2, Player HighPlayer, string mode)
            {
                if (player1.Score > HighPlayer.Score)
                {
                    HighPlayer.Score = player1.Score;
                    HighPlayer.Name = player1.Name;
                }
                if (player2.Score > HighPlayer.Score && mode != "vsComputer")
                {
                    HighPlayer.Score = player2.Score;
                    HighPlayer.Name = player2.Name;
                }
                Console.WriteLine();
                Console.WriteLine($"Player 1: {player1.Name}         Score: {player1.Score}");
                Console.WriteLine();
                Console.WriteLine($"Player 2: {player2.Name}         Score: {player2.Score}");
                Console.WriteLine();
                Console.WriteLine($"High Score: {HighPlayer.Score}          PlayerName: {HighPlayer.Name}");
                Score.Score.SaveHighScore(HighPlayer);
            }
            public static bool Restart(bool res)
            {
                Console.Write("Do you want to play another round ?: (yes/no) :");
                string ans = Console.ReadLine().ToLower();
                if (ans == "yes")
                    return true;
                else
                {
                    HandleEndEvent();
                    return false;
                }

            }
            private static void HandleWinEvent(string winner)
            {
                Console.WriteLine($"Congratulations, {winner} wins!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
            private static void HandleEndEvent()
            {
                Console.WriteLine("Good Game! See Ya Next Time! ");
                
            }
            public static void Main(string[] args)
            {
                bool res = true;
                string mode = "vsPlyayer";
                Console.WriteLine("Do You want to play vs Computer ? :(yes/no):");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    mode = "vsComputer";
                    ComputerPlayer computer = new ComputerPlayer();
                }
                Player player1, player2;
                PlayersCreation(out player1, out player2, mode);
                Player HighPlayer = Score.Score.LoadHighScore();
                while (res)
                {
                    Board Round = new Board(player1, player2);
                    Round.WinEvent += HandleWinEvent;
                    Round.EndEvent += HandleEndEvent;
                    Round.Play(player1, player2, mode);
                    Display(player1, player2, HighPlayer, mode);
                    Predicate<bool> restartPredicate = new Predicate<bool>(Restart);
                    res = restartPredicate.Invoke(true);
                }

                Score.Score.SaveHighScore(HighPlayer);

            }
        }
    }
}