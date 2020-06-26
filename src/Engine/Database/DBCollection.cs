using System.IO;

namespace ERPG
{
    /// <summary>
    /// User should access data from db collection <br />
    /// Instead create database instance themselves
    /// </summary>
    public class DBCollection
    {
        public static LanguageDatabase DB_Language;
        public static PlayerDatabase DB_Player;

        /// <summary>
        /// Make instance for database <br />
        /// </summary>
        public static void Initialize()
        {
            Logger.Log("Systen", "Initialize", "Start initialize database collection...");
            
            DB_Language = new LanguageDatabase();
            DB_Player = new PlayerDatabase();

            if (!Directory.Exists("data")) Directory.CreateDirectory("data");
        }
    }
}
