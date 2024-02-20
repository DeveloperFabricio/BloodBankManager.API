using BloodBankManager.Application.Models.ViewModels;
using MediatR;

namespace BloodBankManager.Application.Queries.GetDonationById
{
    public class GetDonationByIdQuery : IRequest<DonationViewModel>
    {
        public GetDonationByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
