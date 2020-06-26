using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPG
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
