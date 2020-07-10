using System;

namespace ERPGCore
{
    public class PercentageIntPropertiesAddition<T> : PropertiesAddition where T : IntPropertiesBase
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

        public PercentageIntPropertiesAddition()
        {

        }

        public PercentageIntPropertiesAddition(float value)
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
            return (int)input * percentage_value;
        }
    }
}
