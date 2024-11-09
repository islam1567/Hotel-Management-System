namespace Hotel_Management_System.Models
{
    public class PaymentMethods
    {
        public int Id { get; set; }
        public string PaymentName { get; set; }
        public virtual Payments Payments { get; set; }
    }
}
