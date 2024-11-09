using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRepository<RolesDto> repo;

        public RoleController(IRepository<RolesDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}", Name = "RoleRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(RolesDto dto)
        {
            if (ModelState.IsValid)
                repo.Add(dto);
            else
                return BadRequest(ModelState);

            var url = Url.Link("RoleRoute", new { id = dto.id });
            return Created(url, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RolesDto dto)
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
