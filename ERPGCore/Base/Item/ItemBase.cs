using System;
using System.Reflection;
using System.Xml;

namespace ERPGCore
{
    /// <summary>
    /// Item contain name && description etc.. basic information item have <br />
    /// </summary>
    [System.Serializable]
    public abstract class ItemBase : EObject
    {
        /// <summary>
        /// The limitation for using this item
        /// </summary>
        /// <returns></returns>
        public abstract Tuple<SearchTerm, int>[] UseLimit();

        /// <summary>
        /// Item's level will define how it looks
        /// </summary>
        public int ItemQuality;

        /// <summary>
        /// How much can it stack in inventory
        /// </summary>
        public int ItemStackMaximum;

        /// <summary>
        /// For extra data loading
        /// </summary>
        /// <param name="root">Xml data root</param>
        public abstract void LoadDataDatail(XmlNode root);

        /// <summary>
        /// For extra data saving
        /// </summary>
        /// <param name="doc">Xml document</param>
        /// <param name="root">Xml data root</param>
        public abstract void SaveDataDatail(XmlDocument doc, XmlElement root);

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
