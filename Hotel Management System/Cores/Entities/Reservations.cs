using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class Reservations : BaseEntity
    {
        public int Id { get; set; }
        public DateTime BookinDate { get; set; }
        public DateTime ChackDate { get; set; }
        public DateTime ChackOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfNights { get; set; }
        public int TotalPrice { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("ReservationStatuses")]
        public int ReseStatusesId { get; set; }
        [ForeignKey("Rooms")]
        public int RoomId { get; set; }
        public virtual Users Users { get; set; }
        public virtual List<FeedBacks> FeedBacks { get; set; }
        public virtual ReservationStatuses ReservationStatuses { get; set; }
        public virtual Payments Payments { get; set; }
        public virtual Rooms Rooms { get; set; }
    }
}
