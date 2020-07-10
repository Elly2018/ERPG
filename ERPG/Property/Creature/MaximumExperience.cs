using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Creature", "MaximumExperience")]
    public class MaximumExperience : IntPropertiesBase
    {
        public MaximumExperience()
        {
        }

        public MaximumExperience(int value) : base(value)
        {
        }
    }
}
