using System.Reflection;

namespace ERPG
{
    /// <summary>
    /// Item contain name && description etc.. basic information item have <br />
    /// </summary>
    [System.Serializable]
    public abstract class ItemBase
    {
        /// <summary>
        /// Item name, it will use for search in database
        /// </summary>
        public SearchTerm ItemName
        {
            get
            {
                SearchKeyword sk = this.GetType().GetCustomAttribute<SearchKeyword>();
                return new SearchTerm(sk);
            }
        }

        /// <summary>
        /// Item description
        /// </summary>
        public abstract SearchTerm ItemDescription();

        /// <summary>
        /// Item's level will define how it looks
        /// </summary>
        public int ItemLevel;

        /// <summary>
        /// How much can it stack in inventory
        /// </summary>
        public int ItemStackMaximum;

        /// <summary>
        /// When user throw the item from inventory
        /// </summary>
        public virtual void Drop() { }

        /// <summary>
        /// When user pick up the item from ground
        /// </summary>
        public virtual void PickUp() { }

        /// <summary>
        /// When item duration is below zero
        /// </summary>
        public virtual void Outdate() { }
    }
}
