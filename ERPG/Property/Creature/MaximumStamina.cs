using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Creature", "MaximumStamina")]
    public class MaximumStamina : IntPropertiesBase
    {
        public MaximumStamina()
        {
        }

        public MaximumStamina(int value) : base(value)
        {
        }
    }
}
