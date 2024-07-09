using System;



namespace ConsoleApp1.Play
{
    public static class Score
    {
        private static string highScoreFilePath = "highscore.txt";

        public static Player CheckHighScore(Player player1, Player player2, Player highPlayer, string mode)
        {
            if (player1.Score > highPlayer.Score)
            {
                highPlayer.Score = player1.Score;
                highPlayer.Name = player1.Name;
            }
            if (player2.Score > highPlayer.Score && mode != "vsComputer")
            {
                highPlayer.Score = player2.Score;
                highPlayer.Name = player2.Name;
            }
            return highPlayer;
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
        public static void SaveHighScore(Player highPlayer)
        {
            try
            {
                File.WriteAllText(highScoreFilePath, $"{highPlayer.Name},{highPlayer.Score}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while saving {e.Message}", e);
            }
        }

    }
}
