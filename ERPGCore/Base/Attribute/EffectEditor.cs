using System;
using System.Collections.Generic;
using System.Reflection;

namespace ERPGCore
{
    /// <summary>
    /// Define class should be in item editor scene
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class EffectEditor : Attribute
    {
        /// <summary>
        /// Effect how ui will display the object
        /// </summary>
        public string registerName;

        public EffectEditor(string _registerName)
        {
            registerName = _registerName;
        }

        /// <summary>
        /// Get all the type contain ItemEditor attribute
        /// </summary>
        /// <returns></returns>
        public static string[] GetDisplayItems()
        {
            List<string> result = new List<string>();
            Assembly ass = Assembly.GetCallingAssembly();
            Type[] types = ass.GetTypes();
            foreach (var i in types)
            {
                if (i.GetCustomAttribute<EffectEditor>() != null)
                {
                    bool exist = false;
                    foreach(var j in result)
                    {
                        if(j == i.GetCustomAttribute<EffectEditor>().registerName)
                        {
                            exist = true;
                        }
                    }

                    if (!exist)
                    {
                        result.Add(i.GetCustomAttribute<EffectEditor>().registerName);
                    }
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Get all the type contain ItemEditor attribute
        /// </summary>
        /// <returns></returns>
        public static Type[] GetDisplayItems(string name)
        {
            List<Type> result = new List<Type>();
            Assembly ass = Assembly.GetCallingAssembly();
            Type[] types = ass.GetTypes();
            foreach (var i in types)
            {
                if (i.GetCustomAttribute<EffectEditor>() != null)
                {
                    if (i.GetCustomAttribute<EffectEditor>().registerName == name) result.Add(i);
                }
            }
            return result.ToArray();
        }
    }
}
