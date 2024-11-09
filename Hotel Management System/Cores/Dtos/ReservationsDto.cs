using Hotel_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Cores.Dtos
{
    public class ReservationsDto : BaseEntity
    {
        public int Id { get; set; }
        public DateTime BookinDate { get; set; }
        public DateTime ChackDate { get; set; }
        public DateTime ChackOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfNights { get; set; }
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public int ReseStatusesId { get; set; }
        public int RoomId { get; set; }
    }
}
