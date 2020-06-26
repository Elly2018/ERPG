namespace ERPG
{
    public class PercentagePropertiesAddition<T> : PropertiesAddition
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
    }
}
