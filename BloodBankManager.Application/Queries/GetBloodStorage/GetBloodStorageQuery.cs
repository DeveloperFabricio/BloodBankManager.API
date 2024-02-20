using BloodBankManager.Application.Models.ViewModels;
using MediatR;

namespace BloodBankManager.Application.Queries.GetBloodStorage
{
    public class GetBloodStorageQuery : IRequest<List<BloodStorageViewModel>>
    {
    }
}
