using Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Score
{
    public static class Score
    {
        private static string highScoreFilePath = "highscore.txt";


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
                Console.WriteLine($"An Error occured while Loaing {e.Message}", e);
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
