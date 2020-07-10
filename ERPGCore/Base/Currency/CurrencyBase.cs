namespace ERPGCore
{
    /// <summary>
    /// Currency unit base <br />
    /// Including function of <br />
    /// 1. Currency value (specified how much does player have this type of currency) <br />
    /// 2. Spending && Anding function <br />
    /// Inherited with <seealso cref="EObject"/>
    /// </summary>
    public abstract class CurrencyBase : EObject
    {
        /// <summary>
        /// Current currency value
        /// </summary>
        private int _value;

        /// <summary>
        /// The public field for user access
        /// </summary>
        public int value
        {
            get
            {
                return _value;
            }
        }

        /// <summary>
        /// Initialize value is 0
        /// </summary>
        public CurrencyBase()
        {
            _value = 0;
        }

        /// <summary>
        /// Initialize with value
        /// </summary>
        /// <param name="value">Currency value</param>
        public CurrencyBase(int value)
        {
            _value = value;
        }

        /// <summary>
        /// Check if currency amount is satisfied needs
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool CanSpawn(int v)
        {
            return v >= _value;
        }

        /// <summary>
        /// Spawn amount of currency
        /// </summary>
        /// <param name="v"></param>
        public void Spawn(int v)
        {
            _value -= v;
        }

        /// <summary>
        /// Adding currency value
        /// </summary>
        /// <param name="v"></param>
        public void Add(int v)
        {
            _value += v;
        }
    }
}
