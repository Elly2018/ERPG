namespace ERPG
{
    [System.Serializable]
    public abstract class Player : CreatureBase
    {
        /// <summary>
        /// The name that is unique id
        /// </summary>
        public string PlayerName;

        /// <summary>
        /// The inventroy information for this player
        /// </summary>
        public CharacterInventory PlayerEquipInventory;

        /// <summary>
        /// The equip inventory information for this player
        /// </summary>
        public PlayerInventory PlayerItemInventory;

        /// <summary>
        /// How many quest this player has pick up
        /// </summary>
        public QuestBase[] InProgress = new QuestBase[0];

        /// <summary>
        /// The classes this player has selected
        /// </summary>
        public ClassBase[] Classes = new ClassBase[0];

        protected Player()
        {
            PlayerEquipInventory = InitializeCharacterInventory();
            PlayerItemInventory = InitializePlayerInventory();
        }

        /// <summary>
        /// Define character inventory worker (equipment inventory)
        /// </summary>
        /// <returns></returns>
        public abstract CharacterInventory InitializeCharacterInventory();

        /// <summary>
        /// Define player inventory worker (items inventory)
        /// </summary>
        /// <returns></returns>
        public abstract PlayerInventory InitializePlayerInventory();

        /// <summary>
        /// Pick up item and adding to player inventory
        /// </summary>
        /// <param name="item">Target</param>
        /// <param name="amount">Number of item</param>
        public void Pickup(ItemBase item, int amount)
        {
            PlayerItemInventory.AddItem(item, amount);
        }
    }
}
