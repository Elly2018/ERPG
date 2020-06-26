namespace ERPG
{
    public class TestPlayerInventory : PlayerInventory
    {
        public TestPlayerInventory()
        {
            ItemRegister = new System.Tuple<ItemBase, int>[10 * 4];
        }
    }
}
