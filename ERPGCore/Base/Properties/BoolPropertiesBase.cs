namespace ERPGCore
{
    public class BoolPropertiesBase : PropertiesBase
    {
        public BoolPropertiesBase()
        {

        }

        public BoolPropertiesBase(bool value)
        {
            bool_value = value;
        }

        public bool bool_value
        {
            get
            {
                return (bool)value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
