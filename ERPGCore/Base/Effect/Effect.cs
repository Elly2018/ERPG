using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ERPGCore
{
    public sealed class Effect
    {
        public static Type[] GetAllEffect()
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<Type> result = new List<Type>();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(EffectBase))) result.Add(i);
            }
            return result.ToArray();
        }

        public static Type GetEffectByName(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(EffectBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm) return i;
                }
            }
            return null;
        }

        public static Type[] GetEffectArrayByName(SearchTerm[] searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<Type> result = new List<Type>();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(EffectBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (searchTerm.Contains(i.GetCustomAttribute<SearchTerm>())) result.Add(i);
                }
            }
            return result.ToArray();
        }

        public static EffectBase[] GetAllEffectInstance()
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<EffectBase> result = new List<EffectBase>();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(EffectBase)))
                {
                    EffectBase buffer = (EffectBase)ass.CreateInstance(i.FullName);
                    result.Add(buffer);
                }
            }
            return result.ToArray();
        }

        public static EffectBase GetEffectInstanceByName(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(EffectBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        EffectBase buffer = (EffectBase)ass.CreateInstance(i.FullName);
                        return buffer;
                    }
                }
            }
            return null;
        }

        public static EffectBase[] GetEffectArrayInstanceByName(SearchTerm[] searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<EffectBase> result = new List<EffectBase>();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(EffectBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (searchTerm.Contains(i.GetCustomAttribute<SearchTerm>()))
                    {
                        EffectBase buffer = (EffectBase)ass.CreateInstance(i.FullName);
                        result.Add(buffer);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
