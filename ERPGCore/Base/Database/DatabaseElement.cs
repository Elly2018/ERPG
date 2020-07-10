using System.Collections.Generic;

namespace ERPGCore
{
    [System.Serializable]
    public class DatabaseElement<T>
    {
        public List<T> Elements = new List<T>();
    }
}
