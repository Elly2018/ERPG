using ERPG;

[SearchKeyword("First", "Sword Man")]
public class SwordMan : ClassBase
{
    public override SkillTreeBase RegisterTree()
    {
        return new SwordManSkillTree();
    }
}

[SearchKeyword("First", "Sword Man")]
public class SwordManSkillTree : SkillTreeBase
{
    public override SkillTreeElement[] RegisterSkills()
    {
        return new SkillTreeElement[] 
        { 
            new SkillTreeElement() { target = new Wield(), requirement_level = null },
            new SkillTreeElement() { target = new Bashing(), requirement_level = null }
        };
    }
}

[SearchKeyword("Sword Man", "Wield")]
public class Wield : SkillBase
{
    public override SkillInformationPack[] RegisterInformationPack()
    {
        return new SkillInformationPack[]
        {
            new SkillInformationPack() { 
                Duration = 1.0f,
                ActiveTime = 0.0f,
                Colddown = 1.0f,

                properties = new PropertiesList ( new PropertiesBase[] 
                { 
                    new Damage() { int_value = 5 } 
                }),

                Addition = new PropertiesAdditionList()
            }, // level 1

            new SkillInformationPack() {
                Duration = 1.0f,
                ActiveTime = 0.0f,
                Colddown = 1.0f,

                properties = new PropertiesList ( new PropertiesBase[] 
                { 
                    new Damage() { int_value = 7 }
                }),

                Addition = new PropertiesAdditionList()
            }, // level 2
        };
    }

    public override void UseToCreature(CreatureBase from, CreatureBase to)
    {
        Strength strength = from.Properties.GetProperty<Strength>();
        int strength_value = (strength == null ? 1 : strength.int_value);
        Health heal = to.Properties.GetProperty<Health>();
        if (heal != null)
        {
            heal.int_value -= strength_value * CurrentLevelInformation.properties.GetProperty<Damage>().int_value;
        }
    }

    public override void UseToMateral(CreatureBase from, MaterialBase to)
    {
        
    }
}

[SearchKeyword("Sword Man", "Bashing")]
public class Bashing : SkillBase
{
    public override SkillInformationPack[] RegisterInformationPack()
    {
        return new SkillInformationPack[]
        {
            new SkillInformationPack() {
                Duration = 1.0f,
                ActiveTime = 0.5f,
                Colddown = 1.5f,

                properties = new PropertiesList ( new PropertiesBase[]
                {
                    new Damage() { int_value = 12 }
                }),

                Addition = new PropertiesAdditionList()
            }, // level 1

            new SkillInformationPack() {
                Duration = 1.0f,
                ActiveTime = 0.5f,
                Colddown = 1.5f,

                properties = new PropertiesList ( new PropertiesBase[]
                {
                    new Damage() { int_value = 15 }
                }),

                Addition = new PropertiesAdditionList()
            }, // level 2
        };
    }

    public override void UseToCreature(CreatureBase from, CreatureBase to)
    {
        Strength strength = from.Properties.GetProperty<Strength>();
        int strength_value = (strength == null ? 1 : strength.int_value);
        Health heal = to.Properties.GetProperty<Health>();
        if (heal != null)
        {
            heal.int_value -= strength_value * CurrentLevelInformation.properties.GetProperty<Damage>().int_value;
        }
    }

    public override void UseToMateral(CreatureBase from, MaterialBase to)
    {
        
    }
}
