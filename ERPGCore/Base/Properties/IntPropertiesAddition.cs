using System;

namespace ERPGCore
{
    public class IntPropertiesAddition<T> : PropertiesAddition where T : IntPropertiesBase
    {
        public int int_value
        {
            get
            {
                return (int)addition;
            }
            set
            {
                addition = value;
            }
        }

        public IntPropertiesAddition()
        {

        }

        public IntPropertiesAddition(int value)
        {
            int_value = value;
        }

        public override bool TypeCheck(Type C)
        {
            return C == typeof(T);
        }

        public override Type GetAdditionType()
        {
            return typeof(T);
        }

        public override object Calculate(object input)
        {
            return (int)input + int_value;
        }
    }
}
