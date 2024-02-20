using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Repositories;
using MediatR;

namespace BloodBankManager.Application.Commands.UpdateDonor
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, Unit>
    {
        private readonly IDonorRepository _donorRepository;
        public UpdateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<Unit> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetDonorByIdAsync(request.Id);

            UpdateDonorAndAddress(request, donor);

            await _donorRepository.SaveChangesAsync();

            return Unit.Value;

        }

        private static void UpdateDonorAndAddress(UpdateDonorCommand request, Donor donor)
        {
            donor.UpdateDonor(request.FullName,
                              request.Gender,
                              request.Weight,
                              request.Address = new Address(request.Address.Street,
                                                            request.Address.City,
                                                            request.Address.State,
                                                            request.Address.ZipCode));
        }
    }
}
