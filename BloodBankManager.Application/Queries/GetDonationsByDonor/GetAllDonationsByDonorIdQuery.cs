using BloodBankManager.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Queries.GetDonationsByDonor
{
    public class GetAllDonationsByDonorIdQuery : IRequest<DonorAndDonationsViewModel>
    {
        public GetAllDonationsByDonorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
