using System.Reflection;

namespace ERPGCore
{
    public abstract class LimitBase : EObject
    {
        /// <summary>
        /// Check user have satisfied the limit require
        /// </summary>
        /// <returns></returns>
        public abstract bool LimitCheck(Player creature);
    }
}
