using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Creature", "Health")]
    public class Health : IntPropertiesBase
    {
        public Health()
        {
        }

        public Health(int value) : base(value)
        {
        }
    }
}
