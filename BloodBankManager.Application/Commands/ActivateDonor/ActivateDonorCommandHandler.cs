using BloodBankManager.Core.Repositories;
using MediatR;

namespace BloodBankManager.Application.Commands.ActivateDonor
{
    public class ActivateDonorCommandHandler : IRequestHandler<ActivateDonorCommand, Unit>
    {
        private readonly IDonorRepository _donorRepository;
        public ActivateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<Unit> Handle(ActivateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetDonorByIdAsync(request.Id);

            donor.ActivateDonor();

            await _donorRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
