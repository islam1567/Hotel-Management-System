using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Cores.Repository
{
    public class PaymentMethodsRepo : IRepository<PaymentMethodsDto>
    {
        private readonly ApplicationDbContext context;

        public PaymentMethodsRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<PaymentMethodsDto> GetAll()
        {
            var result = context.PaymentMethods.
                Select(e => new PaymentMethodsDto
                {
                    Id = e.Id,
                    PaymentName = e.PaymentName,
                }).ToList();
            return result;
        }

        public PaymentMethodsDto GetById(int id)
        {
            var result = context.PaymentMethods.
                Select(e => new PaymentMethodsDto
                {
                    Id = e.Id,
                    PaymentName = e.PaymentName,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(PaymentMethodsDto Dto)
        {
            var paymethod = new PaymentMethods
            {
                Id = Dto.Id,
                PaymentName = Dto.PaymentName,
            };
            context.PaymentMethods.Add(paymethod);
            context.SaveChanges();
        }

        public void Update(int id, PaymentMethodsDto Dto)
        {
            var paymethod = context.PaymentMethods.FirstOrDefault(e => e.Id == id);
            paymethod.Id = Dto.Id;
            paymethod.PaymentName = Dto.PaymentName;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var paymethod = context.PaymentMethods.FirstOrDefault(e => e.Id == id);
            context.PaymentMethods.Remove(paymethod);
            context.SaveChanges();
        }
    }
}
