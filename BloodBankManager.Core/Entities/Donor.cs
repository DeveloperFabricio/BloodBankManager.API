using BloodBankManager.Core.Enums;

namespace BloodBankManager.Core.Entities
{
    public class Donor : BaseEntity
    {
        protected Donor(){ }
        public Donor(string fullName, string email, DateTime birthDate, Gender gender, double weight, BloodType bloodType, RhFactor rhFactor, Address address)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;
            Active = true;
            Donations = new List<Donation>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactor RhFactor { get; private set; }
        public List<Donation> Donations { get; private set; }
        public Address Address { get; private set; }
        public bool Active { get; private set; }


        public void UpdateDonor(string fullName, Gender gender, double weight, Address address)
        {
            FullName = fullName;
            Gender = gender;
            Weight = weight;
            Address = address;
        }

        public void InactiveDonor()
        {
            Active = false;
        }

        public void ActivateDonor()
        {
            Active = true;
        }
    }
}
