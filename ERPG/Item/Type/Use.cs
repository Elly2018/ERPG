using ERPGCore;
using System;

namespace ERPG.Item
{
    /// <summary>
    /// consumable items
    /// </summary>
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
