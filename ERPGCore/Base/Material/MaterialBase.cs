using System;

namespace ERPGCore
{
    /// <summary>
    /// Can be gathering by creature interaction
    /// </summary>
    [System.Serializable]
    public abstract class MaterialBase : EObjectWithPrefab
    {
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
