using System;
using System.Collections.Generic;
using System.Reflection;

namespace ERPG
{
    public sealed class Effect
    {
        public static Type GetItemTypeByKeyword(SearchKeyword keyword)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.GetType().IsSubclassOf(typeof(EffectBase)))
                {
                    SearchKeyword sk = i.GetCustomAttribute<SearchKeyword>();
                    if (sk != null)
                    {
                        if (sk == keyword) return i;
                    }
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
                if (i.GetType().IsSubclassOf(typeof(EffectBase)))
                {
                    SearchKeyword sk = i.GetCustomAttribute<SearchKeyword>();
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
