using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSebrae.Application.Interfaces;
using TesteSebrae.Application.Models;

namespace TesteSebrae.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepServices _cepServices;

        public CepController(ICepServices cepServices)
        {
            _cepServices = cepServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _cepServices.GetCEPDataAsync();

            if (result is null) return BadRequest("Problemas ao consultar o CEP");

            return Ok(result);
        }
    }
}
