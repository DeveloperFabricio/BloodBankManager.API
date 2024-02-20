using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Commands.ActivateDonor
{
    public class ActivateDonorCommand : IRequest<Unit>
    {
        public ActivateDonorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
