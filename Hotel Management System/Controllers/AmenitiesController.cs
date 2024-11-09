using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Hotel_Management_System.Cores.Repository;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IRepository<AmenitiesDto> repo;

        public AmenitiesController(IRepository<AmenitiesDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}", Name ="AmenitiesRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(AmenitiesDto dto)
        {
            if (ModelState.IsValid)
                repo.Add(dto);
            else
                return BadRequest(ModelState);

            var url = Url.Link("AmenitiesRoute", new { id = dto.Id });
            return Created(url, dto); 
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AmenitiesDto dto)
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
