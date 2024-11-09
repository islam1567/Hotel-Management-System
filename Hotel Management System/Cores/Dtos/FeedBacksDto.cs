using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Cores.Dtos
{
    public class FeedBacksDto
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int ReservationId { get; set; }
    }
}
