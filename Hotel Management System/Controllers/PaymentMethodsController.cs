using Hotel_Management_System.Cores.Dtos;
using Hotel_Management_System.Cores.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IRepository<PaymentMethodsDto> repo;

        public PaymentMethodsController(IRepository<PaymentMethodsDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}", Name = "PaymentMethodRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(PaymentMethodsDto dto)
        {
            if (ModelState.IsValid)
                repo.Add(dto);
            else
                return BadRequest(ModelState);

            var url = Url.Link("PaymentMethodRoute", new { id = dto.Id });
            return Created(url, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PaymentMethodsDto dto)
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
