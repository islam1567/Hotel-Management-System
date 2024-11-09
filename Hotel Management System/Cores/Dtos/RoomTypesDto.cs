using Hotel_Management_System.Models;

namespace Hotel_Management_System.Cores.Dtos
{
    public class RoomTypesDto : BaseEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public bool IsActive { get; set; }
        public string Descreption { get; set; }
    }
}
