namespace ERPGCore
{
    /// <summary>
    /// Basic object with <br />
    /// 1. Name search function <br />
    /// 2. Dscription field <br />
    /// 3. Icon specified
    /// </summary>
    public abstract class EObject : EName
    {
        /// <summary>
        /// Description
        /// </summary>
        public abstract SearchTerm Description();

        /// <summary>
        /// Get icon path
        /// </summary>
        /// <returns></returns>
        public abstract string GetIconPath();
    }
}
