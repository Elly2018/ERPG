using System;

namespace ERPG
{
    /// <summary>
    /// Provide object class data search term
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SearchKeyword : Attribute
    {
        /// <summary>
        /// Each element is belong to category
        /// </summary>
        public string Category;

        /// <summary>
        /// Each actual data is bind with label keyword
        /// </summary>
        public string Label;

        public SearchKeyword(string category, string label)
        {
            Category = category;
            Label = label;
        }
    }
}
