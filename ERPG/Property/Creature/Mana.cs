using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Creature", "Mana")]
    public class Mana : IntPropertiesBase
    {
        public Mana()
        {
        }

        public Mana(int value) : base(value)
        {
        }
    }
}
