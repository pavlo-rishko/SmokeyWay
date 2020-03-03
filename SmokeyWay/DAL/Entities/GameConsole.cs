using System.Collections.Generic;

namespace DAL.Entities
{
    public class GameConsole : BaseEntity
    {
        public int GameConsoleTypeId { get; set; }

        public GameConsoleType GameConsoleType { get; set; }

        public Table Table { get; set; }

        public IList<GameConsoleToGame> GameConsolesGames { get; set; }
    }
}
