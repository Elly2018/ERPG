using System;

namespace ERPGCore
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomMonsterInventory : Attribute
    {
        public Type type;

        public CustomMonsterInventory(Type _type)
        {
            type = _type;
        }
    }
}
