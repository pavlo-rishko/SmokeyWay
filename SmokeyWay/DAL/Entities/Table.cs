using System.Collections.Generic;

namespace DAL.Entities
{
    public class Table : BaseEntity
    {
        public string Identifier { get; set; }

        public int DepartamentId { get; set; }

        public Departament Departament { get; set; }

        public int SeatingCapacity { get; set; }

        public int GameConsoleId { get; set; }

        public GameConsole GameConsole { get; set; }

        public IList<OnlineTableReservation> OnlineTableReservations { get; set; }

        public IList<OfflineTableReservation> OfflineTableResrvations { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
