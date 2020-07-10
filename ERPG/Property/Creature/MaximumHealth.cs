using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Creature", "MaximumHealth")]
    public class MaximumHealth : IntPropertiesBase
    {
        public MaximumHealth()
        {
            
        }

        public MaximumHealth(int value) : base(value)
        {
        }
    }
}
