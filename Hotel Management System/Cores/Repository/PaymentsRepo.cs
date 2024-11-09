using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Cores.Repository
{
    public class PaymentsRepo : IRepository<PaymentsDto>
    {
        private readonly ApplicationDbContext context;

        public PaymentsRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<PaymentsDto> GetAll()
        {
            var result = context.Payments.
                Select(e => new PaymentsDto
                {
                    Id = e.Id,
                    Price = e.Price,
                    PayedAt = e.PayedAt,
                    PayMethodId = e.PayMethodId,
                    ReservationId = e.ReservationId,
                }).ToList();
            return result;
        }

        public PaymentsDto GetById(int id)
        {
            var result = context.Payments.
                Select(e => new PaymentsDto
                {
                    Id = e.Id,
                    Price = e.Price,
                    PayedAt = e.PayedAt,
                    PayMethodId = e.PayMethodId,
                    ReservationId = e.ReservationId,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(PaymentsDto Dto)
        {
            var payment = new Payments
            {
                Id = Dto.Id,
                Price = Dto.Price,
                PayedAt = Dto.PayedAt,
                PayMethodId = Dto.PayMethodId,
                ReservationId = Dto.ReservationId,
            };
            context.Payments.Add(payment);
            context.SaveChanges();
        }

        public void Update(int id, PaymentsDto Dto)
        {
            var payment = context.Payments.FirstOrDefault(e => e.Id == id);
            payment.Id = Dto.Id;
            payment.Price = Dto.Price;
            payment.PayedAt = Dto.PayedAt;
            payment.PayMethodId = Dto.PayMethodId;
            payment.ReservationId = Dto.ReservationId;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var payment = context.Payments.FirstOrDefault(e => e.Id == id);
            context.Payments.Remove(payment);
            context.SaveChanges();
        }
        
    }
}
