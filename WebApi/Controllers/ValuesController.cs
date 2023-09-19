
using BusinessLayer.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IBL_Personas _blPersonas;

        public PersonaController(IBL_Personas _bl)
        {
            _blPersonas = _bl;
        }

        [ProducesResponseType(typeof(Persona), 200)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_blPersonas.Get());
        }

        [ProducesResponseType(typeof(PeriodicTimer), 200)]
        [HttpGet("{documento}")]
        public IActionResult Get(string documento)
        {
            return Ok(_blPersonas.Get(documento));
        }

        [ProducesResponseType(typeof(Persona), 200)]
        [HttpPost]
        public IActionResult Post([FromBody] Persona p)
        {
            _blPersonas.Insert(p);
            return Ok();
        }

        [ProducesResponseType(typeof(Persona), 200)]
        [HttpPut]
        public IActionResult Put([FromBody] Persona x)
        {
            _blPersonas.Update(x);
            return Ok();
        }

        [ProducesResponseType(typeof(Persona), 200)]
        [HttpDelete]
        public IActionResult Delete(string documento)
        {
            _blPersonas.Delete(documento);
            return Ok();
        }
    }
}
