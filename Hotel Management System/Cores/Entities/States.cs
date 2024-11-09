using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hotel_Management_System.Models
{
    public class States
    {
        public int Id { get; set; }
        public int Descreption { get; set; }
        [ForeignKey("Countires")]
        public int CountryId { get; set; }
        public virtual Countires Countires { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
