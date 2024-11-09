using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Cores.Repository
{
    public class AmenitiesRepo : IRepository<AmenitiesDto>
    {
        private readonly ApplicationDbContext context;

        public AmenitiesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<AmenitiesDto> GetAll()
        {
            var result = context.Amenities.
                Select(e => new AmenitiesDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Descreption = e.Descreption,
                    IsActive = e.IsActive,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).ToList();
            return result;
        }

        public AmenitiesDto GetById(int id)
        {
            var result = context.Amenities.
                Select(e => new AmenitiesDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Descreption = e.Descreption,
                    IsActive = e.IsActive,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }
        public void Add(AmenitiesDto dto)
        {
            var Amenities = new Amenities
            {
                Id = dto.Id,
                Name = dto.Name,
                Descreption = dto.Descreption,
                IsActive = dto.IsActive,
                CreatedAt = dto.CreatedAt,
                CreatedBy = dto.CreatedBy,
                ModifiedAt = dto.ModifiedAt,
                ModifiedBy = dto.ModifiedBy,

            };
            context.Amenities.Add(Amenities);
            context.SaveChanges();
        }       

        public void Update(int id, AmenitiesDto dto)
        {
            var Amenities = context.Amenities.FirstOrDefault(e => e.Id == id);
            Amenities.Id = dto.Id;
            Amenities.Name = dto.Name;
            Amenities.Descreption = dto.Descreption;
            Amenities.IsActive = dto.IsActive;
            Amenities.CreatedAt = dto.CreatedAt;
            Amenities.CreatedBy = dto.CreatedBy;
            Amenities.ModifiedAt = dto.ModifiedAt;
            Amenities.ModifiedBy = dto.ModifiedBy;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var amenieties = context.Amenities.FirstOrDefault(e => e.Id == id);
            context.Amenities.Remove(amenieties);
            context.SaveChanges();
        }
        
    }
}
