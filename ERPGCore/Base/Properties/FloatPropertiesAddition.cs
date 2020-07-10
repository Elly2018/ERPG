using System;

namespace ERPGCore
{
    public class FloatPropertiesAddition<T> : PropertiesAddition where T : FloatPropertiesBase
    {
        public float float_value
        {
            get
            {
                return (float)addition;
            }
            set
            {
                addition = value;
            }
        }

        public FloatPropertiesAddition()
        {

        }

        public FloatPropertiesAddition(float value)
        {
            float_value = value;
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
            return (float)input + float_value;
        }
    }
}
