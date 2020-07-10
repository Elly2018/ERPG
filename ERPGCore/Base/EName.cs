using System.Reflection;

namespace ERPGCore
{
    /// <summary>
    /// Basic object with <br />
    /// 1. Name search function
    /// </summary>
    public abstract class EName
    {
        /// <summary>
        /// Get this object's name
        /// </summary>
        public SearchTerm Name
        {
            get
            {
                return this.GetType().GetCustomAttribute<SearchTerm>();
            }
        }
    }
}
