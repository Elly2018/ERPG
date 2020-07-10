using System;

namespace ERPGCore
{
    /// <summary>
    /// Monster's drop inventory <br />
    /// </summary>
    [System.Serializable]
    public abstract class MonsterInventory : InventoryBase
    {
        /// <summary>
        /// Define the Equip object array this monster will drop
        /// </summary>
        /// <returns></returns>
        public abstract Tuple<SearchTerm, int>[] GetEquipDrop();

        /// <summary>
        /// Define the Use object array this monster will drop
        /// </summary>
        /// <returns></returns>
        public abstract Tuple<SearchTerm, int>[] GetUseDrop();

        /// <summary>
        /// Define the Special object array this monster will drop
        /// </summary>
        /// <returns></returns>
        public abstract Tuple<SearchTerm, int>[] GetSpecialDrop();

        /// <summary>
        /// Define the Weapon object array this monster will drop
        /// </summary>
        /// <returns></returns>
        public abstract Tuple<SearchTerm, int>[] GetWeaponDrop();

        /// <summary>
        /// Called when monster inventory initialized
        /// </summary>
        public virtual void Init()
        {
            ItemRegister = new Tuple<ItemBase, int>[
                GetEquipDrop().Length + GetUseDrop().Length + GetSpecialDrop().Length + GetWeaponDrop().Length
                ];
        }
    }
}
