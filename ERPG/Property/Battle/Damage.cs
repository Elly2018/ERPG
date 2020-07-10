using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Battle", "Damage")]
    public class Damage : IntPropertiesBase
    {
        public Damage()
        {
        }

        public Damage(int value) : base(value)
        {
        }
    }
}
