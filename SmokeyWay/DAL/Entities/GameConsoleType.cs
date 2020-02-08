using System.Collections.Generic;

namespace DAL.Entities
{
    public class GameConsoleType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<GameConsole> GameConsoles { get; set; }
    }
}
