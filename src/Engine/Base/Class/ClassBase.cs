namespace ERPG
{
    /// <summary>
    /// Information for the classes <br />
    /// Contain skill tree
    /// </summary>
    public abstract class ClassBase
    {
        /// <summary>
        /// Each class have their own skill tree
        /// </summary>
        public SkillTreeBase skillTrees;

        public ClassBase()
        {
            this.skillTrees = RegisterTree();
        }

        /// <summary>
        /// Use in initialization, for define the skill tree for this class
        /// </summary>
        /// <returns></returns>
        public abstract SkillTreeBase RegisterTree();
    }
}
