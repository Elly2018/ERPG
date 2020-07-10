using ERPGCore;

namespace ERPG.Item
{
    /// <summary>
    /// Normally equip have only 1 stack amount
    /// </summary>
    public abstract class Equip : ItemBase
    {
        public Equip()
        {
            ItemStackMaximum = 1;
        }
    }
}