namespace Hotel_Management_System.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Descreption { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
