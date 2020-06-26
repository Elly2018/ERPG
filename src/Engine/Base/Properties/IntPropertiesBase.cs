namespace ERPG
{
    public class IntPropertiesBase : PropertiesBase
    {
        public IntPropertiesBase()
        {

        }

        public IntPropertiesBase(int value)
        {
            int_value = value;
        }

        public int int_value
        {
            get
            {
                return (int)value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
