using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Commands.UpdateDonor
{
    public class UpdateDonorCommand : IRequest<Unit>
    {
        public UpdateDonorCommand(int id, string fullName, Gender gender, double weight, Address address)
        {
            Id = id;
            FullName = fullName;
            Gender = gender;
            Weight = weight;
            Address = address;
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public Address Address { get; set; }
    }
}
