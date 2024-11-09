using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hotel_Management_System.Cores.Repository
{
    public class UsersRepo : IRepository<UsersDto>
    {
        private readonly ApplicationDbContext context;

        public UsersRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<UsersDto> GetAll()
        {
            var result = context.Users.
                Select(e => new  UsersDto
                {
                    Id = e.Id,
                    IsActive = e.IsActive,
                    CountryId = e.CountryId,
                    LastLogin = e.LastLogin,
                    RoleId = e.RoleId,
                    StateId = e.StateId,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).ToList();
            return result;
        }

        public UsersDto GetById(int id)
        {
            var result = context.Users.
                Select(e => new UsersDto
                {
                    Id = e.Id,
                    IsActive = e.IsActive,
                    CountryId = e.CountryId,
                    LastLogin = e.LastLogin,
                    RoleId = e.RoleId,
                    StateId = e.StateId,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }
        public void Add(UsersDto Dto)
        {
            var user = new Users
            {
                Id = Dto.Id,
                IsActive = Dto.IsActive,
                CountryId = Dto.CountryId,
                LastLogin = Dto.LastLogin,
                RoleId = Dto.RoleId,
                StateId = Dto.StateId,
                CreatedAt = Dto.CreatedAt,
                CreatedBy = Dto.CreatedBy,
                ModifiedAt = Dto.ModifiedAt,
                ModifiedBy = Dto.ModifiedBy,
            };
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Update(int id, UsersDto Dto)
        {
            var user = context.Users.FirstOrDefault(e => e.Id == id);
            user.Id = Dto.Id;
            user.IsActive = Dto.IsActive;
            user.CountryId = Dto.CountryId;
            user.LastLogin = Dto.LastLogin;
            user.RoleId = Dto.RoleId;
            user.StateId = Dto.StateId;
            user.CreatedAt = Dto.CreatedAt;
            user.CreatedBy = Dto.CreatedBy;
            user.ModifiedAt = Dto.ModifiedAt;
            user.ModifiedBy = Dto.ModifiedBy;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var user = context.Users.FirstOrDefault(e => e.Id == id);
            context.Users.Remove(user);
            context.SaveChanges();
        }
        
    }
}
