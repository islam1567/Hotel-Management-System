using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;
using System.Data;

namespace Hotel_Management_System.Cores.Repository
{
    public class RoomsRepo : IRepository<RoomsDto>
    {
        private readonly ApplicationDbContext context;

        public RoomsRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<RoomsDto> GetAll()
        {
            var result = context.Rooms.
                Select(e => new RoomsDto
                {
                    id = e.Id,
                    Price = e.Price,
                    RoomNumber = e.RoomNumber,
                    BedType = e.BedType,
                    ViewType = e.ViewType,
                    IsActive = e.IsActive,
                    RoomStatusId = e.RoomStatusId,
                    RoomTypeId = e.RoomTypeId,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).ToList();
            return result;
        }

        public RoomsDto GetById(int id)
        {
            var result = context.Rooms.
                Select(e => new RoomsDto
                {
                    id = e.Id,
                    Price = e.Price,
                    RoomNumber = e.RoomNumber,
                    BedType = e.BedType,
                    ViewType = e.ViewType,
                    IsActive = e.IsActive,
                    RoomStatusId = e.RoomStatusId,
                    RoomTypeId = e.RoomTypeId,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).FirstOrDefault(e => e.id == id);
            return result;
        }
        public void Add(RoomsDto Dto)
        {
            var room = new Rooms
            {
                Id = Dto.id,
                Price = Dto.Price,
                RoomNumber = Dto.RoomNumber,
                BedType = Dto.BedType,
                ViewType = Dto.ViewType,
                IsActive = Dto.IsActive,
                RoomStatusId = Dto.RoomStatusId,
                RoomTypeId = Dto.RoomTypeId,
                CreatedAt = Dto.CreatedAt,
                CreatedBy = Dto.CreatedBy,
                ModifiedAt = Dto.ModifiedAt,
                ModifiedBy = Dto.ModifiedBy,
            };
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void Update(int id, RoomsDto Dto)
        {
            var room = context.Rooms.FirstOrDefault(e => e.Id == id);
            room.Id = Dto.id;
            room.Price = Dto.Price;
            room.RoomNumber = Dto.RoomNumber;
            room.BedType = Dto.BedType;
            room.ViewType = Dto.ViewType;
            room.IsActive = Dto.IsActive;
            room.RoomStatusId = Dto.RoomStatusId;
            room.RoomTypeId = Dto.RoomTypeId;
            room.CreatedAt = Dto.CreatedAt;
            room.CreatedBy = Dto.CreatedBy;
            room.ModifiedAt = Dto.ModifiedAt;
            room.ModifiedBy = Dto.ModifiedBy;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var room = context.Rooms.FirstOrDefault(e => e.Id == id);
            context.Rooms.Remove(room);
            context.SaveChanges();
        }

    }
}
