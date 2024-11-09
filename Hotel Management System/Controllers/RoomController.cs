using Hotel_Management_System.Cores.AppDbContext;
using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository<RoomsDto> repo;

        public RoomController(ApplicationDbContext context, IRepository<RoomsDto> repo)
        {
            this.context = context;
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}", Name = "RoomRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }
        

        [HttpPost]
        public IActionResult Add(RoomsDto dto)
        {
            if (ModelState.IsValid)
                repo.Add(dto);
            else
                return BadRequest(ModelState);

            var url = Url.Link("RoomRoute", new { id = dto.id });
            return Created(url, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RoomsDto dto)
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
