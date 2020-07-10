using ERPG.Property;
using ERPGCore;
using System;

namespace ERPG
{
    [SearchTerm("Slime", "TinySlime")]
    public class TinySlime : Monster
    {
        public TinySlime(MonsterInventory inventoryRegister) : base(inventoryRegister)
        {
            Properties.Add(new Level(1));
            Properties.Add(new MaximumHealth(20));
            Properties.Add(new Health(20));
            Properties.Add(new Attack(3));
        }

        public override void Attacked(CreatureBase target)
        {

        }

        public override SearchTerm Description()
        {
            throw new NotImplementedException();
        }

        public override string GetIconPath()
        {
            throw new NotImplementedException();
        }

        public override string GetPrefabPath()
        {
            throw new NotImplementedException();
        }

        public override void Spawn()
        {
            throw new NotImplementedException();
        }

        public override void Update(float Delta)
        {
            throw new NotImplementedException();
        }
    }

    [SearchTerm("Slime", "TinySlimeDrop")]
    public class TinySlimeDrop : MonsterInventory
    {
        public override Tuple<SearchTerm, int>[] GetEquipDrop()
        {
            throw new NotImplementedException();
        }

        public override Tuple<SearchTerm, int>[] GetSpecialDrop()
        {
            throw new NotImplementedException();
        }

        public override Tuple<SearchTerm, int>[] GetUseDrop()
        {
            throw new NotImplementedException();
        }

        public override Tuple<SearchTerm, int>[] GetWeaponDrop()
        {
            throw new NotImplementedException();
        }
    }
}
