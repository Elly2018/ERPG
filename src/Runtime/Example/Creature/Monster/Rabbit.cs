using ERPG;
using System;

[SearchKeyword("1_5", "Rabbit")]
public class Rabbit : Monster
{
    private Counter Counter;
    private Vec3 TargetPos;

    public Rabbit(MonsterInventory inventoryRegister) : base(inventoryRegister)
    {
        Properties.Add(new MaximumHealth(100));
        Properties.Add(new Health(100));
        Properties.Add(new MaximumMana(100));
        Properties.Add(new Mana(100));
        Properties.Add(new Aggressive(false));
        Properties.Add(new Damage(10));

        Counter = new Counter(GoRandomPos, 8.0f);
    }

    public override void Attacked(CreatureBase target)
    {
        if (Creature.IsPlayer(target))
        {
            Target = (Player)target;
        }
    }

    public override void Spawn()
    {
        Animation.SetBool("Moving", false);
        TargetPos = GetPosition();
    }

    public override void Update(float Delta)
    {
        Counter.Update(Delta);

        float dis = PathFinder.Distance(TargetPos);
        Animation.SetBool("Moving", dis > 1.2f);

        if(Properties.GetProperty<Health>().int_value == 0)
            ZoneDeathEvent(this);
    }

    private void GoRandomPos()
    {
        TargetPos = zone.RandomPositionInZone();
        PathFinder.Move(TargetPos);
    }
}

[SearchKeyword("1_5", "Rabbit")]
public class RabbitDrop : MonsterInventory
{
    public override Tuple<SearchTerm, int>[] GetEquipDrop()
    {
        return new Tuple<SearchTerm, int>[0];
    }

    public override Tuple<SearchTerm, int>[] GetSpecialDrop()
    {
        return new Tuple<SearchTerm, int>[0];
    }

    public override Tuple<SearchTerm, int>[] GetUseDrop()
    {
        return new Tuple<SearchTerm, int>[0];
    }

    public override Tuple<SearchTerm, int>[] GetWeaponDrop()
    {
        return new Tuple<SearchTerm, int>[0];
    }
}
