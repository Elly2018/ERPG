using ERPG;
using System;

[SearchKeyword("Heal Potion", "Middle Heal Potion")]
public class MiddleHealPotion : Use
{
    public override Tuple<SearchTerm, int>[] Consume()
    {
        return new Tuple<SearchTerm, int>[] {
            new Tuple<SearchTerm, int>(new SearchTerm("Heal Potion", "Middle Heal Potion Effect"), 10) 
        };
    }

    public override SearchTerm ItemDescription()
    {
        return null;
    }
}
