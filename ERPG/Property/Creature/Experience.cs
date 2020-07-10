using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Creature", "Experience")]
    public class Experience : IntPropertiesBase
    {
        public Experience()
        {
        }

        public Experience(int value) : base(value)
        {
        }
    }
}
