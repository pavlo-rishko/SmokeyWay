using System;

namespace DAL.Entities
{
    public class OfflineTableReservation
    {
        public int Id { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public string UserName { get; set; }

        public string UserPhoneNumber { get; set; }

        public DateTime ReservationDateTime { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
