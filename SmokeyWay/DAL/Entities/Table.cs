using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Table
    {
        public Table()
        {
            this.OnlineTableReservations = new List<OnlineTableReservation>();
            this.Orders = new List<Order>();
        }

        public int Id { get; set; }

        public string Identifier { get; set; }

        public int DepartmentId { get; set; }

        public int SeatingCapacity { get; set; }

        public int ConsoleId { get; set; }

        public ICollection<OnlineTableReservation> OnlineTableReservations { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
