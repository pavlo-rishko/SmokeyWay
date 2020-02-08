namespace DAL.Entities
{
    public class GameConsoleGame
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public int GameConsoleId { get; set; }

        public GameConsole GameConsole { get; set; }
    }
}
