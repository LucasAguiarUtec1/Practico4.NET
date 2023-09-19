using BusinessLayer.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeichuloController : ControllerBase
    {
        private readonly IBL_Veichulos _blVeichulos;

        public VeichuloController(IBL_Veichulos blVeichulos)
        {
            _blVeichulos = blVeichulos;
        }

        [ProducesResponseType(typeof(Veichulo), 200)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_blVeichulos.Get());
        }

        [ProducesResponseType(typeof(Veichulo), 200)]
        [HttpGet("matricula")]
        public IActionResult Get(string matricula)
        {
            return Ok(_blVeichulos.Get(matricula));
        }

        [ProducesResponseType(typeof(Veichulo), 200)]
        [HttpDelete]
        public IActionResult Delete(string matricula)
        {
            _blVeichulos.Delete(matricula);
            return Ok();
        }

        [ProducesResponseType(typeof(Veichulo), 200)]
        [HttpPost]
        public IActionResult Post([FromBody] Veichulo veichulo)
        {
            _blVeichulos.Insert(veichulo);
            return Ok();
        }

        [ProducesResponseType(typeof(Veichulo), 200)]
        [HttpPut]
        public IActionResult Put([FromBody] Veichulo veichulo)
        {
            _blVeichulos.Update(veichulo);
            return Ok();
        }
    }
}
