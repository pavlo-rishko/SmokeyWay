namespace DAL.Entities
{
    public class OfflineTableReservation : BaseEntity
    {
        public int TableId { get; set; }

        public Table Table { get; set; }

        public DateTime ReservationDateTime { get; set; }

        public string ClientName { get; set; }

        public string ClientPhoneNumber { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
