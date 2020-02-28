using System;

namespace DAL.Entities
{
    public class OnlineTableReservation : BaseEntity<int>
    {
        public int TableId { get; set; }

        public Table Table { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
