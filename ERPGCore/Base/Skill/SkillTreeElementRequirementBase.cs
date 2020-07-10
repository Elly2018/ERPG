namespace ERPGCore
{
    public abstract class SkillTreeElementRequirementBase
    {
        /// <summary>
        /// If player satisfied the skill requirement
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public abstract bool Satisfied(Player player);
    }
}
