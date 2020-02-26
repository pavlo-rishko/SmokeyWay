using System.Collections.Generic;

namespace DAL.Entities
{
    public class GameConsoleType : BaseEntity<int>
    {
        public string Name { get; set; }

        public IList<GameConsole> GameConsoles { get; set; }
    }
}
