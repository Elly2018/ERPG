using System;

namespace ERPG
{
    /// <summary>
    /// consumable items
    /// </summary>
    [System.Serializable]
    [ItemEditor("Use")]
    public abstract class Use : ItemBase
    {
        public EffectList Effects;

        /// <summary>
        /// What effect will trigger and how long
        /// </summary>
        /// <returns></returns>
        public abstract Tuple<SearchTerm, int>[] Consume();
    }
}
