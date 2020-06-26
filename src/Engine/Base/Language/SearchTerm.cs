using System;

namespace ERPG
{
    /// <summary>
    /// Represent the string itself <br />
    /// It's useful for search language database
    /// </summary>
    [System.Serializable]
    public class SearchTerm : IEquatable<SearchTerm>
    {
        /// <summary>
        /// Category keyword
        /// Seach method in <seealso cref="LanguageList"/>
        /// </summary>
        public string Category_Keyword;

        /// <summary>
        /// Label keyword <br />
        /// Seach method in <seealso cref="Category"/>
        /// </summary>
        public string Label_Keyword;

        public SearchTerm(string category, string label)
        {
            Category_Keyword = category;
            Label_Keyword = label;
        }

        public SearchTerm(SearchKeyword sk)
        {
            Category_Keyword = sk.Category;
            Label_Keyword = sk.Label;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SearchTerm);
        }

        public bool Equals(SearchTerm other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;

            return Label_Keyword == other.Label_Keyword && Category_Keyword == other.Category_Keyword;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Label_Keyword.GetHashCode();
                hashCode = (hashCode * 397) ^ Category_Keyword.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Use for check if two search term content the same
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator ==(SearchTerm obj1, SearchTerm obj2)
        {
            return obj1.Label_Keyword == obj2.Label_Keyword && obj1.Category_Keyword == obj2.Category_Keyword;
        }

        /// <summary>
        /// Use for check if two search term content the difference
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator !=(SearchTerm obj1, SearchTerm obj2)
        {
            return obj1.Label_Keyword != obj2.Label_Keyword || obj1.Category_Keyword != obj2.Category_Keyword;
        }

        public override string ToString()
        {
            return $" {Category_Keyword}:{Label_Keyword} ";
        }
    }
}
