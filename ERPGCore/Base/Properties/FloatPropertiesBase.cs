namespace ERPGCore
{
    public class FloatPropertiesBase : PropertiesBase
    {
        public float float_value
        {
            get
            {
                return (float)value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
