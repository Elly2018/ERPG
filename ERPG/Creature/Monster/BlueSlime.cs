﻿using ERPGCore;
using System;

namespace ERPG
{
    [SearchTerm("Slime", "BlueSlime")]
    public class BlueSlime : Monster
    {
        public BlueSlime(MonsterInventory inventoryRegister) : base(inventoryRegister)
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

    [SearchTerm("Slime", "BlueSlimeDrop")]
    public class BlueSlimeDrop : MonsterInventory
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
