using BloodBankManager.Core.Enums;

namespace BloodBankManager.Core.Entities
{
    public class BloodStorage : BaseEntity
    {
        public BloodStorage()
        {

        }
        public BloodStorage(BloodType bloodType, RhFactor rhFactor, int quantityMl)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
        }

        public BloodType BloodType  { get; private set; }
        public RhFactor RhFactor { get; private set; }
        public int QuantityMl { get; private set; }

        public void UpdateQuantity(int quantityMl)
        {
            QuantityMl += quantityMl;
        }
    }
}
