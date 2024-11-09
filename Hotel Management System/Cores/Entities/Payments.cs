using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime PayedAt { get; set; }
        [ForeignKey("PaymentMethods")]
        public int PayMethodId { get; set; }
        [ForeignKey("Reservations")]
        public int ReservationId { get; set; }
        public virtual PaymentMethods PaymentMethods { get; set; }
        public virtual Reservations Reservations { get; set; }
    }
}
