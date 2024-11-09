using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Cores.Dtos
{
    public class PaymentsDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime PayedAt { get; set; }
        public int PayMethodId { get; set; }
        public int ReservationId { get; set; }
    }
}
