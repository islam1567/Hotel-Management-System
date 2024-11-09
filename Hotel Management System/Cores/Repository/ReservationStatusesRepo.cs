using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Cores.Repository
{
    public class ReservationStatusesRepo : IRepository<ReservationStatusesDto>
    {
        private readonly ApplicationDbContext context;

        public ReservationStatusesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<ReservationStatusesDto> GetAll()
        {
            var result = context.ReservationStatuses.
                Select(e => new ReservationStatusesDto
                {
                    Id = e.Id,
                    StatusName = e.StatusName,
                }).ToList();
            return result;
        }

        public ReservationStatusesDto GetById(int id)
        {
            var result = context.ReservationStatuses.
                Select(e => new ReservationStatusesDto
                {
                    Id = e.Id,
                    StatusName = e.StatusName,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(ReservationStatusesDto Dto)
        {
            var reservationStatus = new ReservationStatuses
            {
                Id = Dto.Id,
                StatusName = Dto.StatusName,
            };
            context.ReservationStatuses.Add(reservationStatus);
            context.SaveChanges();
        }

        public void Update(int id, ReservationStatusesDto Dto)
        {
            var reservationStatus = context.ReservationStatuses.FirstOrDefault(e => e.Id == id);
            reservationStatus.Id = Dto.Id;
            reservationStatus.StatusName = Dto.StatusName;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var reservationStatus = context.Reservations.FirstOrDefault(e => e.Id == id);
            context.Reservations.Remove(reservationStatus);
            context.SaveChanges();
        }

    }
}
