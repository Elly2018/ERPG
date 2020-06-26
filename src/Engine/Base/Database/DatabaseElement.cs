using System.Collections.Generic;

namespace ERPG
{
    [System.Serializable]
    public class DatabaseElement<T>
    {
        public List<T> Elements = new List<T>();
    }
}
