using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Commands.UpdateDonation
{
    public class UpdateDonationCommand : IRequest<Unit>
    {
        public UpdateDonationCommand(int id, int donorId, int quantityMl)
        {
            Id = id;
            DonorId = donorId;
            QuantityMl = quantityMl;
        }
        public int Id { get; set; }
        public int DonorId { get; set; }
        public int QuantityMl { get; set; }
    }
}
