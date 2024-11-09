namespace Hotel_Management_System.Models
{
    public class RoomStatuses
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public string Descreption { get; set; }
        public virtual List<Rooms> Rooms { get; set; }
    }
}
