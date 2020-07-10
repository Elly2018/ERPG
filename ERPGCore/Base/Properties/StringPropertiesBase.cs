namespace ERPGCore
{
    public class StringPropertiesBase : PropertiesBase
    {
        public string string_value
        {
            get
            {
                return (string)value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
