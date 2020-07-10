using System;

namespace ERPGCore
{
    public class PercentageFloatPropertiesAddition<T> : PropertiesAddition where T : FloatPropertiesBase
    {
        public float percentage_value
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

        public PercentageFloatPropertiesAddition()
        {

        }

        public PercentageFloatPropertiesAddition(float value)
        {
            percentage_value = value;
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
            return (float)input * percentage_value;
        }
    }
}
