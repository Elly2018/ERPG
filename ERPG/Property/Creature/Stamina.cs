using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Creature", "Stamina")]
    public class Stamina : IntPropertiesBase
    {
        public Stamina()
        {
        }

        public Stamina(int value) : base(value)
        {
        }
    }
}
