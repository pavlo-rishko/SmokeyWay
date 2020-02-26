using System;

namespace DAL.Entities
{
    public class OfflineTableReservation : BaseEntity<int>
    {
        public int TableId { get; set; }

        public Table Table { get; set; }

        public string UserName { get; set; }

        public string UserPhoneNumber { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
