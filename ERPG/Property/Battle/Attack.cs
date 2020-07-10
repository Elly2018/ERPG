using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Battle", "Attack")]
    public class Attack : IntPropertiesBase
    {
        public Attack()
        {
        }

        public Attack(int value) : base(value)
        {
        }
    }
}
