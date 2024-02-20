using BloodBankManager.Application.Models.ViewModels;
using MediatR;

namespace BloodBankManager.Application.Queries.GetAllDonations
{
    public class GetAllDonationsQuery : IRequest<List<DonationViewModel>>
    {

    }
}
