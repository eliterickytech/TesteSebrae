using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSebrae.Application;
using TesteSebrae.Application.Interfaces;
using TesteSebrae.Domain.Interfaces;

namespace TesteSebrae.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaServices _contaServices;

        public ContaController(IContaServices contaServices)
        {
            _contaServices = contaServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string conta)
        {
            var result = await _contaServices.InsertContaAsync(conta);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromForm] string conta, int Id)
        {
            var result = await _contaServices.UpdateContaAsync(conta, Id);

            if (result == null) return BadRequest();

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] int Id)
        {
            var result = await _contaServices.DeleteContaAsync(Id);

            if (result == null) return BadRequest();

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _contaServices.SelectContaAsync();

            if (result == null) return BadRequest();

            return Ok(result);

        }
    }
}
