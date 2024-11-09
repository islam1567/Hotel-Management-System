using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hotel_Management_System.Cores.Repository
{
    public class CountryRepo : IRepository<CountryDto>
    {
        private readonly ApplicationDbContext context;

        public CountryRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<CountryDto> GetAll()
        {
            var result = context.Countires
                .Select(e => new CountryDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Code = e.Code,
                    IsActive = e.IsActive,
                }).ToList();
            
            return result;
        }

        public CountryDto GetById(int id)
        {
            var result = context.Countires.
                Select(e => new CountryDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Code = e.Code,
                    IsActive = e.IsActive,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(CountryDto countryDto)
        {
            var country = new Countires
            {
                Id = countryDto.Id,
                Name = countryDto.Name,
                Code = countryDto.Code,
                IsActive = countryDto.IsActive,
            };
            context.Countires.Add(country);
            context.SaveChanges();
        }

        public void Update(int id, CountryDto Dto)
        {
            var country = context.Countires.FirstOrDefault(e => e.Id == id);
            country.Id = Dto.Id;
            country.Name = Dto.Name;
            country.Code = Dto.Code;
            country.IsActive = Dto.IsActive;
            context.SaveChanges(); 
        }

        public void Dalete(int id)
        {
            var country = context.Countires.FirstOrDefault(e => e.Id  == id);
            context.Countires.Remove(country);
            context.SaveChanges();
        }

    }
}
