namespace ERPGCore
{
    /// <summary>
    /// Basic object with <br />
    /// 1. Name search function <br />
    /// 2. Dscription field <br />
    /// 3. Icon specified <br />
    /// 4. Prefab link
    /// </summary>
    public abstract class EObjectWithPrefab : EObject
    {
        /// <summary>
        /// Object prefab path in resoruces directory
        /// </summary>
        /// <returns></returns>
        public abstract string GetPrefabPath();
    }
}
