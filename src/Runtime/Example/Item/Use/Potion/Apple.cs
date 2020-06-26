using ERPG;
using System;

[SearchKeyword("Heal Potion", "Apple")]
public class Apple : Use
{
    public override Tuple<SearchTerm, int>[] Consume()
    {
        return new Tuple<SearchTerm, int>[] {
            new Tuple<SearchTerm, int>(new SearchTerm("Heal Potion", "Apple Effect"), 1)
        };
    }

    public override SearchTerm ItemDescription()
    {
        return new SearchTerm("HealItem", "Apple");
    }
}
