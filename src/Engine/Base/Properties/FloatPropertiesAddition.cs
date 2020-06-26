namespace ERPG
{
    public class FloatPropertiesAddition<T> : PropertiesAddition
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
    }
}
