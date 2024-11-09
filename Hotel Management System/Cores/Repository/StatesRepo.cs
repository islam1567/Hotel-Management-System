using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Cores.Repository
{
    public class StatesRepo : IRepository<StatesDto>
    {
        private readonly ApplicationDbContext context;

        public StatesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<StatesDto> GetAll()
        {
            var result = context.States.
                Select(e => new StatesDto
                {
                    Id = e.Id,
                    Descreption = e.Descreption,
                    CountryId = e.CountryId,
                }).ToList();
            return result;
        }

        public StatesDto GetById(int id)
        {
            var result = context.States.
                Select(e => new StatesDto
                {
                    Id = e.Id,
                    Descreption = e.Descreption,
                    CountryId = e.CountryId,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }
        public void Add(StatesDto Dto)
        {
            var state = new States
            {
                Id = Dto.Id,
                Descreption = Dto.Descreption,
                CountryId = Dto.CountryId,
            };
            context.States.Add(state);
            context.SaveChanges();
        }

        public void Update(int id, StatesDto Dto)
        {
            var state = context.States.FirstOrDefault(e => e.Id == id);
            state.Id = Dto.Id;
            state.Descreption = Dto.Descreption;
            state.CountryId = Dto.CountryId;
        }

        public void Dalete(int id)
        {
            var state = context.States.FirstOrDefault(e => e.Id == id);
            context.States.Remove(state);
            context.SaveChanges();
        }
 
    }
}
