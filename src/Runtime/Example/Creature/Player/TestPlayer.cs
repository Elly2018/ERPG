using ERPG;

[SearchKeyword("Test", "Player")]
public class TestPlayer : Player
{
    public override CharacterInventory InitializeCharacterInventory()
    {
        return new TestCharacterInventory();
    }

    public override PlayerInventory InitializePlayerInventory()
    {
        return new TestPlayerInventory();
    }

    public override void Death()
    {
        
    }

    public override void Spawn()
    {
        
    }

    public override void Update(float Delta)
    {
        
    }

    public override void Attacked(CreatureBase target)
    {
        
    }
}
