namespace Hotel_Management_System.Models
{
    public class RoomTypes : BaseEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public bool IsActive { get; set; }
        public string Descreption { get; set; }
    }
}
