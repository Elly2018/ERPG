using System.Reflection;

namespace ERPGCore
{
    public class Inventory
    {
        public static InventoryBase GetInventoryBaseBySearchTerm(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(InventoryBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return (InventoryBase)ass.CreateInstance(i.FullName);
                    }
                }
            }
            return null;
        }

        public static InventoryBase GetInventoryBySearchTerm(SearchTerm searchTerm, Assembly ass)
        {
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(InventoryBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return (InventoryBase)ass.CreateInstance(i.FullName);
                    }
                }
            }
            return null;
        }
    }
}
