using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Creature", "MaximumMana")]
    public class MaximumMana : IntPropertiesBase
    {
        public MaximumMana()
        {
        }

        public MaximumMana(int value) : base(value)
        {
        }
    }
}
