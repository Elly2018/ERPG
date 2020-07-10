using System;
using System.Collections.Generic;
using System.Reflection;

namespace ERPGCore
{
    public class QuestList
    {
        public static Type[] CanTakeQuests(Player player)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<Type> result = new List<Type>();
            foreach(var i in ass.GetTypes())
            {

            }
            return result.ToArray();
        }

        public static Type[] ProgressingQuests(Player player)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<Type> result = new List<Type>();
            foreach (var i in ass.GetTypes())
            {

            }
            return result.ToArray();
        }

        public static Type[] FinishedQuests(Player player)
        {
            Assembly ass = Assembly.GetCallingAssembly();
            List<Type> result = new List<Type>();
            foreach (var i in ass.GetTypes())
            {

            }
            return result.ToArray();
        }
    }
}
