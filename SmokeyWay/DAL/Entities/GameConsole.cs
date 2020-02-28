using System.Collections.Generic;

namespace DAL.Entities
{
    public class GameConsole : BaseEntity<int>
    {
        public int GameConsoleTypeId { get; set; }

        public GameConsoleType GameConsoleType { get; set; }

        public Table Table { get; set; }

        public IList<GameConsoleGame> GameConsolesGames { get; set; }
    }
}
