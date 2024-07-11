using ConsoleApp1.Extensions;

namespace ConsoleApp1.Play
{
    public class Play
    {
        public bool Result { get; set; } = true;
        public string Mode { get; set; }

        public void PlayersCreation(out Player player1)
        {
            Console.Write("Player Name: ");
            string playerName = Console.ReadLine() ?? string.Empty;
            player1 = new Player(playerName);
        }
        public void Display(Player player1, Player player2, Player highPlayer, string mode)
        {

            highPlayer = Score.CheckHighScore(player1, player2, highPlayer, mode);
            player1.DisplayScore(1);
            player2.DisplayScore(2);
            highPlayer.DisplayAndSaveHigherScore();

        }
        public bool Restart(bool result)
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
        public void HandleEndEvent()
        {
            Console.WriteLine("Good Game! See Ya Next Time! ");

        }
    }
}
