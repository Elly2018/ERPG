namespace ERPG
{
    /// <summary>
    /// The skill map for define how to skill system works
    /// </summary>
    [System.Serializable]
    public abstract class SkillTreeBase
    {
        /// <summary>
        /// The element define the content of the tree
        /// </summary>
        public SkillTreeElement[] skills;

        public SkillTreeBase()
        {
            skills = RegisterSkills();
        }

        /// <summary>
        /// Use in initialization, Define skills content for the tree
        /// </summary>
        /// <returns></returns>
        public abstract SkillTreeElement[] RegisterSkills();
    }
}
