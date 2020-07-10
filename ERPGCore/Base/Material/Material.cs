using System;
using System.Reflection;

namespace ERPGCore
{
    public class Material
    {
        public static Type GetMaterialBySearchterm(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.GetCustomAttribute<SearchTerm>() != null && i.IsSubclassOf(typeof(MaterialBase)))
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return i;
                    }
                }
            }
            return null;
        }

        public static MaterialBase GetMaterialInstanceBySearchterm(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.GetCustomAttribute<SearchTerm>() != null && i.IsSubclassOf(typeof(MaterialBase)))
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return (MaterialBase)ass.CreateInstance(i.FullName);
                    }
                }
            }
            return null;
        }
    }
}
