namespace ERPG
{
    /// <summary>
    /// Normally equip have only 1 stack amount
    /// </summary>
    [System.Serializable]
    [ItemEditor("Equipment")]
    public abstract class Equip : ItemBase
    {
        public Equip()
        {
            ItemStackMaximum = 1;
        }
    }
}