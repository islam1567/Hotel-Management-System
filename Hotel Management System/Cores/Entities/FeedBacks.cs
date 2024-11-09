using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class FeedBacks
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Users")]
        public int UserId  { get; set; }
        [ForeignKey("Reservations")]
        public int ReservationId  { get; set; }
        public virtual Users Users { get; set; }
        public virtual Reservations Reservations { get; set; }
    }
}
