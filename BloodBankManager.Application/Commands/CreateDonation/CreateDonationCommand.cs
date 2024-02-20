using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Commands.CreateDonation
{
    public class CreateDonationCommand : IRequest<int>
    {
        public CreateDonationCommand(int donorId, DateTime donationDate, int quantityMl)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            QuantityMl = quantityMl;
        }

        public int DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityMl { get; set; }
    }
}
