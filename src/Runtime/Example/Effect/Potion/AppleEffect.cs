using ERPG;
using UnityEngine;

[SearchKeyword("Heal Potion", "Apple Effect")]
public class AppleEffect : EffectBase
{
    public override SearchTerm EffectDescription()
    {
        return new SearchTerm("HealItem", "AppleEffect");
    }

    public override void EachSecond(CreatureBase target)
    {
        int heal = target.Properties.GetProperty<Health>().int_value;
        int maxheal = target.Properties.GetProperty<MaximumHealth>().int_value;

        heal += 10;
        heal = Mathf.Clamp(heal, 0, maxheal);
        target.Properties.GetProperty<Health>().int_value = heal;
    }
}
