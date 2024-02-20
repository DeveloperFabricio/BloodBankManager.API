using BloodBankManager.Application.Commands.CreateDonation;
using BloodBankManager.Application.Queries.GetAllDonations;
using BloodBankManager.Application.Queries.GetDonationById;
using BloodBankManager.Application.Queries.GetDonationsRelatory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManager.API.Controllers
{
    [Route("api/v1/donations")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDonationsQuery();

            var donations = await _mediator.Send(query);

            return Ok(donations);
        }

        [HttpGet("last-30-days")]
        public async Task<IActionResult> GetLast30Days()
        {
           var query = new GetDonationsRelatoryQuery();
           
           var donationsLast30Days = await _mediator.Send(query);

           return Ok(donationsLast30Days);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDonationByIdQuery(id);

            var donation = await _mediator.Send(query);

            return Ok(donation);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDonationCommand createDonationCommand)
        {
            var id = await _mediator.Send(createDonationCommand);

            return CreatedAtAction(nameof(GetById), new { id }, createDonationCommand);
        }
    }
}
