using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels.MappingViewModels;
using MediatR;

namespace BloodBankManager.Application.Queries.GetDonorById
{
    public class GetDonorByIdQuery : IRequest<DonorViewModel>
    {
        public GetDonorByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
