using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hotel_Management_System.Cores.Repository
{
    public class RoomTypesRepo : IRepository<RoomTypesDto>
    {
        private readonly ApplicationDbContext context;

        public RoomTypesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<RoomTypesDto> GetAll()
        {
            var result = context.RoomTypes.
                Select(e => new RoomTypesDto
                {
                    Id = e.Id,
                    TypeName = e.TypeName,
                    Descreption = e.Descreption,
                    IsActive = e.IsActive,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).ToList();
            return result;
        }

        public RoomTypesDto GetById(int id)
        {
            var result = context.RoomTypes.
                Select(e => new RoomTypesDto
                {
                    Id = e.Id,
                    TypeName = e.TypeName,
                    Descreption = e.Descreption,
                    IsActive = e.IsActive,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }
        public void Add(RoomTypesDto Dto)
        {
            var roomtype = new RoomTypes
            {
                Id = Dto.Id,
                TypeName = Dto.TypeName,
                Descreption = Dto.Descreption,
                IsActive = Dto.IsActive,
                CreatedAt = Dto.CreatedAt,
                CreatedBy = Dto.CreatedBy,
                ModifiedAt = Dto.ModifiedAt,
                ModifiedBy = Dto.ModifiedBy,
            };
            context.RoomTypes.Add(roomtype);
            context.SaveChanges();
        }

        public void Update(int id, RoomTypesDto Dto)
        {
            var roomtype = context.RoomTypes.FirstOrDefault(e => e.Id == id);
            roomtype.Id = Dto.Id;
            roomtype.TypeName = Dto.TypeName;
            roomtype.Descreption = Dto.Descreption;
            roomtype.IsActive = Dto.IsActive;
            roomtype.CreatedAt = Dto.CreatedAt;
            roomtype.CreatedBy = Dto.CreatedBy;
            roomtype.ModifiedAt = Dto.ModifiedAt;
            roomtype.ModifiedBy = Dto.ModifiedBy;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var roomtype = context.RoomTypes.FirstOrDefault(e => e.Id == id);
            context.RoomTypes.Remove(roomtype);
            context.SaveChanges();
        }
 
    }
}
