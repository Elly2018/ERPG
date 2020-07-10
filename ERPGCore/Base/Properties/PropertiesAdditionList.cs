using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPGCore
{
    public class PropertiesAdditionList : Collection<PropertiesAddition>
    {
        public PropertiesAdditionList()
        {

        }

        public PropertiesAdditionList(List<PropertiesAddition> properties)
        {
            foreach (var i in properties)
            {
                this.Add(i);
            }
        }

        public PropertiesAdditionList(PropertiesAddition[] properties)
        {
            foreach (var i in properties)
            {
                this.Add(i);
            }
        }

        public PropertiesList Calculate(PropertiesList obj)
        {
            foreach(var i in this)
            {
                foreach(var j in obj)
                {
                    if(i.TypeCheck(j.GetType()))
                    {
                        j.value = i.Calculate(j.value);
                        break;
                    }
                }
            }
            return obj;
        }

        /// <summary>
        /// Check if property type is in list
        /// </summary>
        /// <typeparam name="T">Property type</typeparam>
        /// <returns></returns>
        public bool ContainProperty<T>()
        {
            foreach (var i in this)
            {
                if (i.GetType() == typeof(T))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check if property type is in list <br />
        /// If in list return back the instance
        /// </summary>
        /// <typeparam name="T">Property type</typeparam>
        /// <returns>Instance</returns>
        public T GetProperty<T>() where T : PropertiesAddition
        {
            foreach (var i in this)
            {
                if (i.GetType() == typeof(T))
                    return (T)i;
            }
            return null;
        }
    }
}
