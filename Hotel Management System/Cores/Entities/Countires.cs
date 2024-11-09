namespace Hotel_Management_System.Models
{
    public class Countires
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<States> States { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
