using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Bcpg;
using warhammer.Entities;
using warhammer.Interfaces;

namespace warhammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : Controller
    {

        private readonly IWarhammerRepository _warhammerRepository;

        public ModelController(IWarhammerRepository warhammerRepository)
        {
            _warhammerRepository = warhammerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Model>))]
        public IActionResult GetModels()
        {
            var models = _warhammerRepository.GetModels();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(models);

        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Model))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Model>> GetModel(int id)
        {
            try
            {
                var model = _warhammerRepository.GetModel(id);

                if (model == null) return NotFound();

                return model;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }



        }


        [HttpPost]
        [ProducesResponseType(200)]
        public Task<ActionResult<Model>> CreateModel(Model model)
        {
            return _warhammerRepository.CreateModel(model);
            

        }
    }
}
