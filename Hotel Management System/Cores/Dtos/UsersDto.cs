using Hotel_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Cores.Dtos
{
    public class UsersDto : BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int RoleId { get; set; }
    }
}
