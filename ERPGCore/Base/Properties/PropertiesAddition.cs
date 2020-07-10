using System;

namespace ERPGCore
{
    public class PropertiesAddition
    {
        public object addition;

        public virtual Type GetAdditionType() { return null; }

        public virtual bool TypeCheck(Type C) { return true; }

        public virtual object Calculate(object input) { return null; }
    }
}
