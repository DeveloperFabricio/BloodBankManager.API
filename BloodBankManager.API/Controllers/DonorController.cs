using BloodBankManager.Application.Commands.ActivateDonor;
using BloodBankManager.Application.Commands.CreateDonor;
using BloodBankManager.Application.Commands.DeleteDonor;
using BloodBankManager.Application.Commands.UpdateDonor;
using BloodBankManager.Application.Queries.GetAllDonors.GetAllDonorsQueries;
using BloodBankManager.Application.Queries.GetDonationsByDonor;
using BloodBankManager.Application.Queries.GetDonorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManager.API.Controllers
{
    [Route("api/v1/donors")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDonorsQuery();

            var donors = await _mediator.Send(query);

            return Ok(donors);
        }

        [HttpGet("actives")]
        public async Task<IActionResult> GetAllActive()
        {
           var query = new GetAllDonorsActiveQuery();

            var donorsActive = await _mediator.Send(query);

            return Ok(donorsActive);
        }

        [HttpGet("inactives")]
        public async Task<IActionResult> GetAllInactive()
        {
            var query = new GetAllDonorsInactiveQuery();

            var donorsInactive = await _mediator.Send(query);

            return Ok(donorsInactive);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDonorByIdQuery(id);

            var donor = await _mediator.Send(query);

            return Ok(donor);
        }

        [HttpGet("{id}/all-donations")]
        public async Task<IActionResult> GetDonationsOfDonor(int id)
        {
            var query = new GetAllDonationsByDonorIdQuery(id);

            var donor = await _mediator.Send(query);

            return Ok(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDonorCommand createDonorCommand)
        {
            var id = await _mediator.Send(createDonorCommand);

            return CreatedAtAction(nameof(GetById), new { id }, createDonorCommand);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id,UpdateDonorCommand updateDonorCommand)
        {
            await _mediator.Send(updateDonorCommand);

            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> ActivateDonor(int id)
        {
            var activateDonor = new ActivateDonorCommand(id);

            await _mediator.Send(activateDonor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteDonor = new DeleteDonorCommand(id);

            await _mediator.Send(deleteDonor);

            return NoContent();
        }
    }
}
