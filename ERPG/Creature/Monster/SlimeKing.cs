using ERPGCore;
using System;

namespace ERPG
{
    [SearchTerm("Slime", "SlimeKing")]
    public class SlimeKing : Monster
    {
        public SlimeKing(MonsterInventory inventoryRegister) : base(inventoryRegister)
        {
        }

        public override void Attacked(CreatureBase target)
        {
            throw new NotImplementedException();
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

    [SearchTerm("Slime", "SlimeKingDrop")]
    public class SlimeKingDrop : MonsterInventory
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
