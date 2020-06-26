namespace ERPG
{
    public class TestCharacterInventory : CharacterInventory
    {
        public TestCharacterInventory()
        {
            ItemRegister = new System.Tuple<ItemBase, int>[6];
        }
    }
}
