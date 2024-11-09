using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Cores.Repository
{
    public class RolesRepo : IRepository<RolesDto>
    {
        private readonly ApplicationDbContext context;

        public RolesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<RolesDto> GetAll()
        {
            var result = context.Roles.
                Select(e => new  RolesDto
                {
                    id = e.Id,
                    IsActive = e.IsActive,
                    Name = e.Name,
                    Descreption = e.Descreption,
                }).ToList();
            return result;
        }

        public RolesDto GetById(int id)
        {
            var result = context.Roles.
                Select(e => new RolesDto
                {
                    id = e.Id,
                    IsActive = e.IsActive,
                    Name = e.Name,
                    Descreption = e.Descreption,
                }).FirstOrDefault(e => e.id == id);
            return result;
        }

        public void Add(RolesDto Dto)
        {
            var role = new Roles
            {
                Id = Dto.id,
                IsActive = Dto.IsActive,
                Name = Dto.Name,
                Descreption = Dto.Descreption,
            };
            context.Roles.Add(role);
            context.SaveChanges();
        }

        public void Update(int id, RolesDto Dto)
        {
            var role = context.Roles.FirstOrDefault(e => e.Id == id);
            role.Id = Dto.id;
            role.IsActive = Dto.IsActive;
            role.Name = Dto.Name;
            role.Descreption = Dto.Descreption;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var role = context.Roles.FirstOrDefault(e => e.Id == id);
            context.Roles.Remove(role);
            context.SaveChanges();
        }

    }
}
