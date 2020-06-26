using System;
using System.Collections.Generic;
using System.Reflection;

namespace ERPG
{
    /// <summary>
    /// Define class should be in item editor scene
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ItemEditor : Attribute
    {
        /// <summary>
        /// Effect how ui will display the object
        /// </summary>
        public string registerName;

        public ItemEditor(string _registerName)
        {
            registerName = _registerName;
        }

        /// <summary>
        /// Get all the type contain ItemEditor attribute
        /// </summary>
        /// <returns></returns>
        public static Tuple<Type, string>[] GetDisplayItems()
        {
            List<Tuple<Type, string>> result = new List<Tuple<Type, string>>();
            Assembly ass = Assembly.GetExecutingAssembly();
            Type[] types = ass.GetTypes();
            foreach(var i in types)
            {
                if(i.GetCustomAttribute<ItemEditor>() != null)
                {
                    result.Add(new Tuple<Type, string>(i, i.GetCustomAttribute<ItemEditor>().registerName));
                }
            }
            return result.ToArray();
        }
    }
}
