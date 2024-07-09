using Computer;
using ConsoleApp1;

namespace Game
{
    public static class Program
    {
        public static void PlayersCreation(out Player player1, out Player player2, string mode)
        {
            Console.Write("Player1 Name: ");
            string playerName = Console.ReadLine() ?? string.Empty;
            player1 = new Player(playerName);
            if (mode == "vsComputer")
            {
                player2 = new ComputerPlayer();
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
            Console.WriteLine($"\nPlayer 1: {player1.Name}                Score: {player1.Score}");
            Console.WriteLine($"\nPlayer 2: {player2.Name}                Score: {player2.Score}");
            Console.WriteLine($"\nHigh Score: {HighPlayer.Score}          PlayerName: {HighPlayer.Name}");
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