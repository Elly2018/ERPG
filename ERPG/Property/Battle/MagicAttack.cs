using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Battle", "MagicAttack")]
    public class MagicAttack : IntPropertiesBase
    {
        public MagicAttack()
        {
        }

        public MagicAttack(int value) : base(value)
        {
        }
    }
}
