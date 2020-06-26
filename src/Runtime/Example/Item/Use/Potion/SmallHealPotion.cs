using ERPG;
using System;

[SearchKeyword("Heal Potion", "Small Heal Potion")]
public class SmallHealPotion : Use
{
    public override Tuple<SearchTerm, int>[] Consume()
    {
        return new Tuple<SearchTerm, int>[] {
            new Tuple<SearchTerm, int>(new SearchTerm("Heal Potion", "Small Heal Potion Effect"), 10)
        };
    }

    public override SearchTerm ItemDescription()
    {
        return null;
    }
}
