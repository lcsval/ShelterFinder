using Microsoft.AspNetCore.Mvc;
using ShelterFinder.Domain.Command;
using ShelterFinder.Domain.Command.Shelter;
using ShelterFinder.Domain.Interfaces.Handlers;
using ShelterFinder.Domain.Interfaces.Repositories.Read;
using System.Threading.Tasks;

namespace ShelterFinder.Api.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ShelterController : Controller
    {
        private readonly IShelterReadRepository _repository;
        private readonly IShelterCommandHandler  _handler;

        public ShelterController(IShelterReadRepository repository,
            IShelterCommandHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet("shelter/get")]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.Get();
            return Ok(result);
        }

        [HttpGet("shelter/getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return Ok(result);
        }

        [HttpPost("shelter/insert")]
        public async Task<IActionResult> Insert([FromBody]ShelterCommand command)
        {
            await _handler.Insert(command);
            return Ok(true);
        }

        [HttpPost("shelter/update")]
        public async Task<IActionResult> Update([FromBody]ShelterCommand command)
        {
            await _handler.Update(command);
            return Ok(true);
        }

        [HttpPost("shelter/delete")]
        public async Task<IActionResult> Delete([FromBody]ShelterCommand command)
        {
            await _handler.Delete(command);
            return Ok(true);
        }

    }
}
