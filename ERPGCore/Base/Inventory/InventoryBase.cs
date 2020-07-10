using ERPGCore;
using System;
using System.Collections.Generic;

namespace ERPGCore
{
    /// <summary>
    /// Inventory contain items register <br />
    /// Base class only have container and basic adding and removing methods
    /// </summary>
    [System.Serializable]
    public abstract class InventoryBase : EName
    {
        protected Tuple<ItemBase, int>[] ItemRegister = new Tuple<ItemBase, int>[0];

        // 
        #region Checker
        /// <summary>
        /// Check if inventory contain target item
        /// </summary>
        /// <param name="item">Target</param>
        protected bool Contain(ItemBase item)
        {
            foreach(var i in ItemRegister)
            {
                if (i.Item1 == item) return true;
            }
            return false;
        }

        /// <summary>
        /// Check if inventory contain target item
        /// </summary>
        /// <param name="item">Target</param>
        /// <param name="index">The index that contain target item</param>
        /// <returns></returns>
        protected bool Contain(ItemBase item, out int[] index)
        {
            List<int> result = new List<int>();
            for(int i = 0; i < ItemRegister.Length; i++)
            {
                Tuple<ItemBase, int> buffer = ItemRegister[i];
                if (buffer.Item1 == item) result.Add(i);
            }

            if (result.Count == 0)
            {
                index = new int[0];
                return false;
            }
            else
            {
                index = result.ToArray();
                return true;
            }
        }

        /// <summary>
        /// Check if inventory contain target item
        /// </summary>
        /// <param name="item">Target</param>
        /// <param name="amount">Amount</param>
        protected bool Contain(ItemBase item, int amount)
        {
            int total = 0;
            foreach (var i in ItemRegister)
            {
                if (i.Item1 == item) total += i.Item2;
            }
            return total >= amount;
        }

        /// <summary>
        /// Check if there is any empty in the inventory
        /// </summary>
        /// <param name="amount">Number of empty slot</param>
        /// <returns></returns>
        protected bool HaveEmptySlot(int amount)
        {
            int total = ItemRegister.Length;
            foreach(var i in ItemRegister)
            {
                if (i.Item1 != null) total--;
            }
            return total >= amount;
        }
        #endregion

        //
        #region Action
        /// <summary>
        /// Set the slot data
        /// </summary>
        /// <param name="index">Index of slot</param>
        /// <param name="target">Target item</param>
        /// <param name="amount">Amount of item to register</param>
        public void SetSlot(int index, ItemBase target, int amount)
        {
            ItemRegister[index] = new Tuple<ItemBase, int>(target, amount);
        }

        /// <summary>
        /// Clean the target slot by index
        /// </summary>
        /// <param name="index">Index of slot</param>
        public void RemoveSlot(int index)
        {
            ItemRegister[index] = new Tuple<ItemBase, int>(null, 0);
        }

        public void CleanSlot()
        {
            for(int i = 0; i < ItemRegister.Length; i++)
            {
                ItemRegister[i] = new Tuple<ItemBase, int>(null, 0);
            }
        }

        /// <summary>
        /// Get an entire inventory data
        /// </summary>
        /// <returns></returns>
        public Tuple<ItemBase, int>[] GetInventory()
        {
            return ItemRegister;
        }
        #endregion
    }
}
