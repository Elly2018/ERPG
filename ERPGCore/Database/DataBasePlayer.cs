namespace ERPGCore
{
    /// <summary>
    /// Use for buffer that contain player database element
    /// </summary>
    public class DataBasePlayer : Player
    {
        public override void Attacked(CreatureBase target) { }

        public override void Death() { }

        public override SearchTerm Description()
        {
            return null;
        }

        public override string GetIconPath()
        {
            return null;
        }

        public override string GetPrefabPath()
        {
            return null;
        }

        public override CharacterInventory InitializeCharacterInventory() { return null; }

        public override PlayerInventory InitializePlayerInventory() { return null; }

        public override void Spawn() { }

        public override void Update(float Delta) { }
    }
}
