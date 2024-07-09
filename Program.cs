using Computer;
using ConsoleApp1;
using ConsoleApp1.Play;

namespace Game
{
    public static class Program
    {
       
        public static void ModeChoice(out Player player2,Play GameRound)
        {
            Console.WriteLine("Do You want to play vs Computer ? :(yes/no):");
            if (Console.ReadLine().ToLower() == "yes")
            {
                GameRound.Mode = "vsComputer";
                player2 = new ComputerPlayer();
            }
            else
            {
                GameRound.Mode = "vsPlyayer";
                GameRound.PlayersCreation(out player2);
            }
        }
        public static void Main(string[] args)
        {
            Play GameRound = new Play();
            Player player1, player2;
            GameRound.PlayersCreation(out player1);
            ModeChoice(out player2,GameRound);
            Player HighPlayer = Score.LoadHighScore();
            while (GameRound.Result)
            {
                Board Round = new Board(player1, player2);
                Round.WinEvent += GameRound.HandleWinEvent;
                Round.EndEvent += GameRound.HandleEndEvent;
                Round.Play(player1, player2, GameRound.Mode);
                GameRound.Display(player1, player2, HighPlayer, GameRound.Mode);
                Predicate<bool> restartPredicate = new Predicate<bool>(GameRound.Restart);
                GameRound.Result = restartPredicate.Invoke(true);
            }
        }
    }
}