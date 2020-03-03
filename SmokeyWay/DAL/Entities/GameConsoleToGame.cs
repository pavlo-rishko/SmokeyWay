namespace DAL.Entities
{
    public class GameConsoleToGame
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public int GameConsoleId { get; set; }

        public GameConsole GameConsole { get; set; }
    }
}
