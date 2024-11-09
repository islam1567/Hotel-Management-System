using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Cores.Repository
{
    public class RoomStatusesRepo : IRepository<RoomStatusesDto>
    {
        private readonly ApplicationDbContext context;

        public RoomStatusesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<RoomStatusesDto> GetAll()
        {
            var result = context.RoomStatuses.
                Select(e => new  RoomStatusesDto
                {
                    Id = e.Id,
                    StatusName = e.StatusName,
                    Descreption = e.Descreption,
                }).ToList();
            return result;
        }

        public RoomStatusesDto GetById(int id)
        {
            var result = context.RoomStatuses.
                Select(e => new RoomStatusesDto
                {
                    Id = e.Id,
                    StatusName = e.StatusName,
                    Descreption = e.Descreption,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }
        public void Add(RoomStatusesDto Dto)
        {
            var roomstatus = new RoomStatuses
            {
                Id = Dto.Id,
                StatusName = Dto.StatusName,
                Descreption = Dto.Descreption,
            };
            context.RoomStatuses.Add(roomstatus);
            context.SaveChanges();
        }

        public void Update(int id, RoomStatusesDto Dto)
        {
            var room = context.RoomStatuses.FirstOrDefault(e => e.Id == id);
            room.Id = Dto.Id;
            room.StatusName = Dto.StatusName;
            room.Descreption = Dto.Descreption;
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
