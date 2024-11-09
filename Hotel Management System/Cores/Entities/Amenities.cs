namespace Hotel_Management_System.Models
{
    public class Amenities : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descreption { get; set; }
        public bool IsActive { get; set; }
    }
}
