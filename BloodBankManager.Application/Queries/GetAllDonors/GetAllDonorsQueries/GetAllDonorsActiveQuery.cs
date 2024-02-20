using BloodBankManager.Application.Models.ViewModels;
using MediatR;

namespace BloodBankManager.Application.Queries.GetAllDonors.GetAllDonorsQueries
{
    public class GetAllDonorsActiveQuery : IRequest<List<AllDonorsViewModel>>
    {

    }
}
