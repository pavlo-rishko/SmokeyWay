using System.Collections.Generic;

namespace DAL.Entities
{
    public class Table
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int SeatingCapacity { get; set; }

        public int ConsoleId { get; set; }

        public IList<OnlineTableReservation> OnlineTableReservations { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
