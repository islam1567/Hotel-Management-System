using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Cores.Repository
{
    public class ReservationsRepo : IRepository<ReservationsDto>
    {
        private readonly ApplicationDbContext context;

        public ReservationsRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<ReservationsDto> GetAll()
        {
            var result = context.Reservations.
                Select(e => new ReservationsDto
                {
                    Id = e.Id,
                    BookinDate = e.BookinDate,
                    ChackDate = e.ChackDate,
                    ChackOutDate = e.ChackOutDate,
                    NumberOfGuests = e.NumberOfGuests,
                    NumberOfNights = e.NumberOfNights,
                    TotalPrice = e.TotalPrice,
                    ReseStatusesId = e.ReseStatusesId,
                    RoomId = e.RoomId,
                    UserId = e.UserId,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).ToList();
            return result;
        }

        public ReservationsDto GetById(int id)
        {
            var result = context.Reservations.
                Select(e => new ReservationsDto
                {
                    Id = e.Id,
                    BookinDate = e.BookinDate,
                    ChackDate = e.ChackDate,
                    ChackOutDate = e.ChackOutDate,
                    NumberOfGuests = e.NumberOfGuests,
                    NumberOfNights = e.NumberOfNights,
                    TotalPrice = e.TotalPrice,
                    ReseStatusesId = e.ReseStatusesId,
                    RoomId = e.RoomId,
                    UserId = e.UserId,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(ReservationsDto Dto)
        {
            var reservation = new Reservations
            {
                Id = Dto.Id,
                BookinDate = Dto.BookinDate,
                ChackDate = Dto.ChackDate,
                ChackOutDate = Dto.ChackOutDate,
                NumberOfGuests = Dto.NumberOfGuests,
                NumberOfNights = Dto.NumberOfNights,
                TotalPrice = Dto.TotalPrice,
                ReseStatusesId = Dto.ReseStatusesId,
                RoomId = Dto.RoomId,
                UserId = Dto.UserId,
                CreatedAt = Dto.CreatedAt,
                CreatedBy = Dto.CreatedBy,
                ModifiedAt = Dto.ModifiedAt,
                ModifiedBy = Dto.ModifiedBy,
            };
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }

        public void Update(int id, ReservationsDto Dto)
        {
            var reservation = context.Reservations.FirstOrDefault(e => e.Id == id);
            reservation.Id = Dto.Id;
            reservation.BookinDate = Dto.BookinDate;
            reservation.ChackDate = Dto.ChackDate;
            reservation.ChackOutDate = Dto.ChackOutDate;
            reservation.NumberOfGuests = Dto.NumberOfGuests;
            reservation.NumberOfNights = Dto.NumberOfNights;
            reservation.TotalPrice = Dto.TotalPrice;
            reservation.ReseStatusesId = Dto.ReseStatusesId;
            reservation.RoomId = Dto.RoomId;
            reservation.UserId = Dto.UserId;
            reservation.CreatedAt = Dto.CreatedAt;
            reservation.CreatedBy = Dto.CreatedBy;
            reservation.ModifiedAt = Dto.ModifiedAt;
            reservation.ModifiedBy = Dto.ModifiedBy;
            context.SaveChanges();
        }

        public void Dalete(int id)
        {
            var reservation = context.Reservations.FirstOrDefault(e => e.Id == id);
            context.Reservations.Remove(reservation);
            context.SaveChanges();
        }

    }
}
