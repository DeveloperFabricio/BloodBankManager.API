using BloodBankManager.Application.Models.ViewModels;
using MediatR;

namespace BloodBankManager.Application.Queries.GetDonationsRelatory
{
    public class GetDonationsRelatoryQuery : IRequest<List<DonationViewModel>>
    {
    }
}
