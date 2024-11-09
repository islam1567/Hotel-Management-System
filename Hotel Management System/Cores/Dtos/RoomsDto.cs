using Hotel_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Cores.Dtos
{
    public class RoomsDto : BaseEntity
    {
        public int id { get; set; }
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        public string BedType { get; set; }
        public string ViewType { get; set; }
        public bool IsActive { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomStatusId { get; set; }
    }
}
