using Hotel_Management_System.Models;

namespace Hotel_Management_System.Cores.Dtos
{
    public class AmenitiesDto : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descreption { get; set; }
        public bool IsActive { get; set; }
    }
}
