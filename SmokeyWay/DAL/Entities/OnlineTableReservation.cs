namespace DAL.Entities
{
    public class OnlineTableReservation : BaseEntity
    {
        public int TableId { get; set; }

        public Table Table { get; set; }

        public DateTime ReservationDateTime { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}