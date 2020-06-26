using System.Collections.Generic;

namespace ERPG
{
    /// <summary>
    /// Category is for sorting all label data array <br />
    /// It also provide a way let label keyword can repeat <br />
    /// As long as they're in different category
    /// </summary>
    [System.Serializable]
    public class Category
    {
        /// <summary>
        /// Search use keyword
        /// </summary>
        public string key;

        /// <summary>
        /// Labels data array 
        /// </summary>
        public List<Label> labels;

        /// <summary>
        /// Loop list get target label instance
        /// </summary>
        /// <param name="keyword">Key</param>
        /// <returns></returns>
        public Label GetLabel(string keyword)
        {
            foreach (var i in labels)
                if (i.key == keyword) return i;
            return null;
        }
    }
}
