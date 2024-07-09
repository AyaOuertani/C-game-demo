using ConsoleApp1;

namespace GameScore
{
    public static class Score
    {
        private static string highScoreFilePath = "highscore.txt";

        public static Player CheckHighScore(Player player1, Player player2, Player HighPlayer, string mode)
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
            return HighPlayer;
        }

        public static Player LoadHighScore()
        {
            try
            {
                if (File.Exists(highScoreFilePath))
                {
                    string[] data = File.ReadAllText(highScoreFilePath).Split(',');
                    if (data.Length == 2 && int.TryParse(data[1], out int score))
                    {
                        return new Player(data[0], score);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An Error occured while Loading {e.Message}", e);
            }
            return new Player();
        }
        public static void SaveHighScore(Player HighPlayer)
        {
            try
            {
                File.WriteAllText(highScoreFilePath, $"{HighPlayer.Name},{HighPlayer.Score}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while saving {e.Message}", e);
            }
        }

    }
}
