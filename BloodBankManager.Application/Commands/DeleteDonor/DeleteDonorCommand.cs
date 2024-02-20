using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Commands.DeleteDonor
{
    public class DeleteDonorCommand : IRequest<Unit>
    {
        public DeleteDonorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
