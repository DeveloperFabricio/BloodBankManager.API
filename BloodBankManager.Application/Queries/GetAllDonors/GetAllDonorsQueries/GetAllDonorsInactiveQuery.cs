using BloodBankManager.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Queries.GetAllDonors.GetAllDonorsQueries
{
    public class GetAllDonorsInactiveQuery : IRequest<List<AllDonorsViewModel>>
    {
    }
}
