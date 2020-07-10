using System;
using System.Collections.Generic;
using System.Reflection;

namespace ERPGCore
{
    /// <summary>
    /// The skill map for define how to skill system works
    /// </summary>
    [System.Serializable]
    public abstract class SkillTreeBase
    {
        /// <summary>
        /// The element define the content of the tree
        /// </summary>
        public SkillTreeElement[] skills;

        public SkillTreeBase()
        {
            skills = RegisterSkills();
        }

        public SkillTreeElement GetElementByTargetSkillSearchTerm(SearchTerm searchTerm)
        {
            foreach(var i in skills)
            {
                Type type = i.Target.GetType();
                if(type.GetCustomAttribute<SearchTerm>() != null)
                {
                    if(type.GetCustomAttribute<SearchTerm>() == searchTerm)
                    {
                        return i;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Use in initialization, Define skills content for the tree
        /// </summary>
        /// <returns></returns>
        public abstract SkillTreeElement[] RegisterSkills();

        /// <summary>
        /// Get all the skill element in tree have
        /// </summary>
        /// <returns></returns>
        public Type[] GetAllElements()
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<Type> result = new List<Type>();
            foreach(var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(ClassBase)))
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }
    }
}
