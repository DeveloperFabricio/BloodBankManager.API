using BloodBankManager.Application.Dto_s;
using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Repositories;
using MediatR;
using System.Text.Json;

namespace BloodBankManager.Application.Commands.CreateDonor
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, int>
    {
        private readonly IDonorRepository _donorRepository;

        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<int> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {

            Donor donor = await CreateDonor(request);

            await _donorRepository.AddDonorAsync(donor);

            return donor.Id;
        }


        private static async Task<ZipCodeDto> GetAddressFromApi(string zipCode)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{zipCode}");

            using (var client = new HttpClient())
            {
                var responseCepApi = await client.SendAsync(request);
                var contentResponse = await responseCepApi.Content.ReadAsStringAsync();
                var objectResponse = JsonSerializer.Deserialize<ZipCodeDto>(contentResponse);

                return objectResponse;
            }
        }

        private static async Task<Donor> CreateDonor(CreateDonorCommand request)
        {
            ZipCodeDto zipCodeDto = await GetAddressFromApi(request.Address.ZipCode);

            return new Donor(request.FullName,
                                  request.Email,
                                  request.BirthDate,
                                  request.Gender,
                                  request.Weight,
                                  request.BloodType,
                                  request.RhFactor,
                                  request.Address = new Address(zipCodeDto.Street ?? request.Address.Street,
                                                                zipCodeDto.City ?? request.Address.City,
                                                                zipCodeDto.State ?? request.Address.State,
                                                                request.Address.ZipCode));
                                  
                                  
        }
    }
}
