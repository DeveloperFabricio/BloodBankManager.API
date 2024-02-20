using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Commands.CreateDonor
{
    public class CreateDonorCommand : IRequest<int>
    {
        public CreateDonorCommand(string fullName, string email, DateTime birthDate, Gender gender, double weight, BloodType bloodType, RhFactor rhFactor, Address address)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; } 
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public Address Address { get; set; }
    }
}
