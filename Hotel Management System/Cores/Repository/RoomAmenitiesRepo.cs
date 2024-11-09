using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Cores.Repository
{
    public class RoomAmenitiesRepo : IRepository<RoomAmenitiesDto>
    {
        private readonly ApplicationDbContext context;

        public RoomAmenitiesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<RoomAmenitiesDto> GetAll()
        {
            var result = context.RoomAmenities.
                Select(e => new  RoomAmenitiesDto
                {
                    RoomTypeId = e.RoomTypeId,
                    AmenityId = e.AmenityId,
                }).ToList();
            return result;
        }

        public RoomAmenitiesDto GetById(int id)
        {
            var result = context.RoomAmenities.
                Select(e => new RoomAmenitiesDto
                {
                    RoomTypeId = e.RoomTypeId,
                    AmenityId = e.AmenityId,
                }).FirstOrDefault(e => e.id == id);
            return result;
        }
        public void Add(RoomAmenitiesDto Dto)
        {
            var roomamenieties = new RoomAmenities
            {
                RoomTypeId = Dto.RoomTypeId,
                AmenityId = Dto.AmenityId,
            };
            context.RoomAmenities.Add(roomamenieties);
            context.SaveChanges();
        }

        public void Update(int id, RoomAmenitiesDto Dto)
        {
            var roomamenieties = context.RoomAmenities.FirstOrDefault(e => e.AmenityId == id);
            roomamenieties.RoomTypeId = Dto.RoomTypeId;
            roomamenieties.AmenityId = Dto.AmenityId;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var roomamenieties = context.RoomAmenities.FirstOrDefault(e => e.AmenityId == id);
            context.RoomAmenities.Remove(roomamenieties);
            context.SaveChanges();
        }
       
    }
}
