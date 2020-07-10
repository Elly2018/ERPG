using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Battle", "Defence")]
    public class Defence : IntPropertiesBase
    {
        public Defence()
        {
        }

        public Defence(int value) : base(value)
        {
        }
    }
}
