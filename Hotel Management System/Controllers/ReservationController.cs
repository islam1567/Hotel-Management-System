using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Cores.Repository;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository<ReservationsDto> repo;

        public ReservationController(ApplicationDbContext context, IRepository<ReservationsDto> repo)
        {
            this.context = context;
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}", Name = "ReservationRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpGet("reservations/{userId}")]
        public IActionResult GetReservationByUserId(int userid)
        {
            var result = context.Reservations.Include(b => b.Users).
                Where(e => e.UserId == userid).
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
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(ReservationsDto dto)
        {
            if (ModelState.IsValid)
                repo.Add(dto);
            else
                return BadRequest(ModelState);

            var url = Url.Link("ReservationRoute", new { id = dto.Id });
            return Created(url, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ReservationsDto dto)
        {
            if (ModelState.IsValid)
                repo.Update(id, dto);
            else
                return BadRequest(ModelState);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repo.Dalete(id);
            return Ok();
        }
    }
}
