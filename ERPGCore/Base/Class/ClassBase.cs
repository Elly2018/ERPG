namespace ERPGCore
{
    /// <summary>
    /// Information for the classes <br />
    /// Contain skill tree
    /// </summary>
    public abstract class ClassBase : EObject
    {
        /// <summary>
        /// Each class have their own skill tree
        /// </summary>
        public SkillTreeBase SkillTrees;

        public int SkillPoint;

        public ClassBase()
        {
            this.SkillTrees = RegisterTree();
        }

        /// <summary>
        /// Use in initialization, for define the skill tree for this class
        /// </summary>
        /// <returns></returns>
        public abstract SkillTreeBase RegisterTree();
    }
}
