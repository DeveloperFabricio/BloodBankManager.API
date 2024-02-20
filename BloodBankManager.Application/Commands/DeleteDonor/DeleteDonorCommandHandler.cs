using BloodBankManager.Core.Repositories;
using MediatR;

namespace BloodBankManager.Application.Commands.DeleteDonor
{
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, Unit>
    {
        private readonly IDonorRepository _donorRepository;
        public DeleteDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<Unit> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetDonorByIdAsync(request.Id);

            donor.InactiveDonor();

            await _donorRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
