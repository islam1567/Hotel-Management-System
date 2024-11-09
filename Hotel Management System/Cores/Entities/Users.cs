using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class Users : BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Countires")]
        public int CountryId { get; set; }
        [ForeignKey("States")]
        public int StateId { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public virtual Countires Countires { get; set; }
        public virtual States States { get; set; }
        public virtual Roles Roles { get; set; }
        public virtual List<FeedBacks> FeedBacks { get; set; }
        public virtual List<Reservations> Reservations { get; set; }

    }
}
