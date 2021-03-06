﻿using System;
using System.Reflection;

namespace ERPGCore
{
    [System.Serializable]
    public abstract class Monster : CreatureBase
    {
        /// <summary>
        /// Monster drop items
        /// </summary>
        private MonsterInventory inventory;

        /// <summary>
        /// When monster death
        /// </summary>
        public Action<Monster> ZoneDeathEvent;

        /// <summary>
        /// The zone handler
        /// </summary>
        public ZoneCommand zone;

        /// <summary>
        /// Must register inventory
        /// </summary>
        /// <param name="inventoryRegister"></param>
        public Monster(MonsterInventory inventoryRegister)
        {
            inventory = inventoryRegister;
        }

        public override void Death()
        {
            // Give player the drop items
            if (Target != null)
            {
                Tuple<ItemBase, int>[] buffer = inventory.GetInventory();
                foreach(var i in buffer)
                {
                    Player p = (Target as Player);
                    if(p != null) p.Pickup(i.Item1, i.Item2);
                }
            }

            if(ZoneDeathEvent != null)
                ZoneDeathEvent.Invoke(this);
        }

        public static Type GetMonsterBySearchterm(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.GetCustomAttribute<SearchTerm>() != null && i.IsSubclassOf(typeof(Monster)))
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return i;
                    }
                }
            }
            return null;
        }

        public static Monster GetMonsterInstanceBySearchterm(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.GetCustomAttribute<SearchTerm>() != null && i.IsSubclassOf(typeof(Monster)))
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return (Monster)ass.CreateInstance(i.FullName, false, BindingFlags.Public | BindingFlags.Instance, null, new object[] {
                            GetMonsterInventory(i)
                        }, null, null);
                    }
                }
            }
            return null;
        }

        public static MonsterInventory GetMonsterInventory(SearchTerm keyword)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.GetCustomAttribute<SearchTerm>() != null && i.IsSubclassOf(typeof(MonsterInventory)))
                {
                    if (i.GetCustomAttribute<SearchTerm>() == keyword)
                    {
                        return (MonsterInventory)ass.CreateInstance(i.FullName);
                    }
                }
            }
            return null;
        }

        public static MonsterInventory GetMonsterInventory(Type monsterType)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.GetCustomAttribute<CustomMonsterInventory>() != null && i.IsSubclassOf(typeof(MonsterInventory)))
                {
                    if(i.GetCustomAttribute<CustomMonsterInventory>().type == monsterType)
                    {
                        return (MonsterInventory)ass.CreateInstance(i.FullName);
                    }
                }
            }
            return null;
        }
    }
}
