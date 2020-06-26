using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPG
{
    /// <summary>
    /// Store set of properties, usually response for creature or items status
    /// </summary>
    public class PropertiesList : Collection<PropertiesBase>
    {
        /// <summary>
        /// Empty list
        /// </summary>
        public PropertiesList()
        {

        }

        /// <summary>
        /// List with initiailize values
        /// </summary>
        /// <param name="properties"></param>
        public PropertiesList(List<PropertiesBase> properties)
        {
            foreach(var i in properties)
            {
                this.Add(i);
            }
        }

        /// <summary>
        /// List with initiailize values
        /// </summary>
        /// <param name="properties"></param>
        public PropertiesList(PropertiesBase[] properties)
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
            foreach(var i in this)
            {
                if(i.GetType() == typeof(T))
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
        public T GetProperty<T>() where T : PropertiesBase
        {
            foreach (var i in this)
            {
                if (i.GetType() == typeof(T))
                    return (T)i;
            }
            return null;
        }

        /// <summary>
        /// My get string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = null;
            foreach(var i in this)
            {
                result += i.GetType().Name + " : " + i.value.ToString() + "\n";
            }
            return result;
        }
    }
}
