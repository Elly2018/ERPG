using System;
using System.Collections.Generic;
using System.Reflection;

namespace ERPGCore
{
    public sealed class Item
    {
        public static Type GetItemTypeByKeyword(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach(var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(ItemBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (searchTerm == i.GetCustomAttribute<SearchTerm>()) return i;
                }
            }
            return null;
        }

        public static Type GetItemTypeByKeyword(SearchTerm searchTerm, Assembly ass)
        {
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(ItemBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (searchTerm == i.GetCustomAttribute<SearchTerm>()) return i;
                }
            }
            return null;
        }

        public static ItemBase GetItemBaseInstanceByKeyword(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(ItemBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (searchTerm == i.GetCustomAttribute<SearchTerm>())
                        return (ItemBase)ass.CreateInstance(i.FullName);
                }
            }
            return null;
        }

        public static ItemBase GetItemBaseInstanceByKeyword(SearchTerm searchTerm, Assembly ass)
        {
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(ItemBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (searchTerm == i.GetCustomAttribute<SearchTerm>())
                        return (ItemBase)ass.CreateInstance(i.FullName);
                }
            }
            return null;
        }

        public static Type[] GetAllItems()
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<Type> result = new List<Type>();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(ItemBase)))
                {
                    SearchTerm sk = i.GetCustomAttribute<SearchTerm>();
                    if (sk != null)
                    {
                        result.Add(i);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
