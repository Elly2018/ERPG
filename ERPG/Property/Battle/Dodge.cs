using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Battle", "Dodge")]
    public class Dodge : IntPropertiesBase
    {
        public Dodge()
        {
        }

        public Dodge(int value) : base(value)
        {
        }
    }
}
