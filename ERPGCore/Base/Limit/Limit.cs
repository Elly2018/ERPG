using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ERPGCore
{
    public class Limit
    {
        public static Type[] GetAllLimit()
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<Type> result = new List<Type>();
            foreach(var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(LimitBase))) result.Add(i);
            }
            return result.ToArray();
        }

        public static Type GetLimitByName(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(LimitBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm) return i;
                }
            }
            return null;
        }

        public static Type[] GetLimitArrayByName(SearchTerm[] searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<Type> result = new List<Type>();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(LimitBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (searchTerm.Contains(i.GetCustomAttribute<SearchTerm>())) result.Add(i);
                }
            }
            return result.ToArray();
        }

        public static LimitBase[] GetAllLimitInstance()
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<LimitBase> result = new List<LimitBase>();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(LimitBase)))
                {
                    LimitBase buffer = (LimitBase)ass.CreateInstance(i.FullName);
                    result.Add(buffer);
                }
            }
            return result.ToArray();
        }

        public static LimitBase GetLimitInstanceByName(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(LimitBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        LimitBase buffer = (LimitBase)ass.CreateInstance(i.FullName);
                        return buffer;
                    }
                }
            }
            return null;
        }

        public static LimitBase[] GetLimitArrayInstanceByName(SearchTerm[] searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<LimitBase> result = new List<LimitBase>();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(LimitBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    LimitBase buffer = (LimitBase)ass.CreateInstance(i.FullName);
                    result.Add(buffer);
                }
            }
            return result.ToArray();
        }
    }
}
