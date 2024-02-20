using BloodBankManager.Application.Queries.GetBloodStorage;
using BloodBankManager.Application.Queries.GetStorageById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManager.API.Controllers
{
    [Route("api/v1/blood-storages")]
    [ApiController]
    public class BloodStorageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BloodStorageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetBloodStorageQuery();

            var storages = await _mediator.Send(query);

            return Ok(storages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetStorageByIdQuery(id);

            var storage = await _mediator.Send(query);

            return Ok(storage);
        }
    }
}
