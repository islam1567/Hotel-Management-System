using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class Rooms : BaseEntity
    {
        public int Id { get; set; }
        //[unique]
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        public string BedType { get; set; }
        public string ViewType { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("RoomTypes")]
        public int RoomTypeId { get; set; }
        [ForeignKey("RoomStatuses")]
        public int RoomStatusId { get; set; }
        public virtual List<Reservations>  Reservations { get; set; }
        public virtual RoomTypes RoomTypes { get; set; }
        public virtual RoomStatuses RoomStatuses { get; set; }
    }
}
