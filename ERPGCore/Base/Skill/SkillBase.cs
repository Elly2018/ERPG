namespace ERPGCore
{
    [System.Serializable]
    public abstract class SkillBase : EObject
    {
        /// <summary>
        /// Level of the skill
        /// </summary>
        public int level = 1;

        /// <summary>
        /// Index = level <br />
        /// In each level what information contain when use the skill
        /// </summary>
        public SkillInformationPack[] informationPacks;

        /// <summary>
        /// Get current level information pack
        /// </summary>
        public SkillInformationPack CurrentLevelInformation
        {
            get
            {
                return informationPacks[level - 1];
            }
        }

        public SkillBase()
        {
            informationPacks = RegisterInformationPack();
        }

        /// <summary>
        /// Use in intialization, Define the level structure
        /// </summary>
        /// <returns></returns>
        public abstract SkillInformationPack[] RegisterInformationPack();

        /// <summary>
        /// When creature use skill to another creature being
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public abstract void UseToCreature(CreatureBase from, CreatureBase to);

        /// <summary>
        /// When creature use skill to a material being
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public abstract void UseToMateral(CreatureBase from, MaterialBase to);
    }
}
