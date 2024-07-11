using ConsoleApp1.Play;
using System.Xml.Linq;

namespace ConsoleApp1.Extensions
{
    public static class PlayerExtensions
    {
        public static void DisplayScore(this Player player, int playerNumber) => Console.WriteLine($"\nPlayer{playerNumber} : {player.Name}         Score: {player.Score}");

        public static void DisplayAndSaveHigherScore(this Player player)
        {
            Console.WriteLine($"\nPlayer Higher : {player.Name}                Score: {player.Score}");
            ConsoleApp1.Play.Score.SaveHighScore(player);
        }
    }
}
