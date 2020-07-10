using System.Reflection;

namespace ERPGCore
{
    public class Class
    {
        public static ClassBase GetClassBaseBySearchTerm(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach(var i in ass.GetTypes())
            {
                if(i.IsSubclassOf(typeof(ClassBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if(i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return (ClassBase)ass.CreateInstance(i.FullName);
                    }
                }
            }
            return null;
        }

        public static ClassBase GetClassBaseBySearchTerm(SearchTerm searchTerm, Assembly ass)
        {
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(ClassBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return (ClassBase)ass.CreateInstance(i.FullName);
                    }
                }
            }
            return null;
        }
    }
}
