namespace ERPG
{
    public class IntPropertiesAddition<T> : PropertiesAddition
    {
        public int float_value
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
    }
}
