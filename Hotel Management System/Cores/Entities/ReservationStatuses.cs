namespace Hotel_Management_System.Models
{
    public class ReservationStatuses
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public virtual Reservations Reservations { get; set; }
    }
}
