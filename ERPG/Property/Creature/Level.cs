using ERPGCore;

namespace ERPG.Property
{
    [SearchTerm("Creature", "Level")]
    public class Level : IntPropertiesBase
    {
        public Level()
        {
        }

        public Level(int value) : base(value)
        {
        }
    }
}
