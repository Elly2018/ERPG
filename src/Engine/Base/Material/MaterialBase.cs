using System;

namespace ERPG
{
    /// <summary>
    /// Can be gathering by creature interaction
    /// </summary>
    [System.Serializable]
    public abstract class MaterialBase
    {
        /// <summary>
        /// Material name, it will use for search in database
        /// </summary>
        public SearchTerm MaterialName;

        /// <summary>
        /// Material description
        /// </summary>
        public SearchTerm MaterialDescription;

        /// <summary>
        /// Check if creature can interact with material
        /// </summary>
        /// <returns></returns>
        public abstract bool CanBeInteractive(CreatureBase target);

        /// <summary>
        /// Interact action
        /// </summary>
        /// <param name="target">Target creature</param>
        /// <param name="use">The skill creature use</param>
        /// <returns>The item creature received</returns>
        public abstract Tuple<ItemBase, int>[] Interact(CreatureBase target, SkillBase use);
    }
}
