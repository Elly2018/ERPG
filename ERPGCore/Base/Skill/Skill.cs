using System.Reflection;

namespace ERPGCore
{
    public class Skill
    {
        public static SkillBase GetSkillBaseBySearchTerm(SearchTerm searchTerm)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(SkillBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return (SkillBase)ass.CreateInstance(i.FullName);
                    }
                }
            }
            return null;
        }

        public static SkillBase GetSkillBaseBySearchTerm(SearchTerm searchTerm, Assembly ass)
        {
            foreach (var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(SkillBase)) && i.GetCustomAttribute<SearchTerm>() != null)
                {
                    if (i.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return (SkillBase)ass.CreateInstance(i.FullName);
                    }
                }
            }
            return null;
        }
    }
}
