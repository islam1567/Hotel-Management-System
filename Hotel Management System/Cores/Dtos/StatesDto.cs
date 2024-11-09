using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Cores.Dtos
{
    public class StatesDto
    {
        public int Id { get; set; }
        public int Descreption { get; set; }
        public int CountryId { get; set; }
    }
}
