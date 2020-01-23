using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Table
    {
        public int Id { get; set; }

        public string Identifier { get; set; }

        public int DepartmentId { get; set; }

        public int SeatingCapacity { get; set; }

        public int ConsoleId { get; set; }

        public List<OnlineTableReservation> OnlineTableReservations { get; set; }

        public List<Order> Orders { get; set; }
    }
}
