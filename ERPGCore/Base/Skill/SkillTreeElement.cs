using System;

namespace ERPGCore
{
    /// <summary>
    /// Define a skill information in the skill map <br />
    /// Contain requirement
    /// </summary>
    public class SkillTreeElement
    {
        /// <summary>
        /// Require another skill level in order to unlock
        /// </summary>
        public int Level;

        /// <summary>
        /// The level maximum upgrade level
        /// </summary>
        public int MaximumLevel;

        /// <summary>
        /// The requirement for this skill
        /// </summary>
        public SkillTreeElementRequirementBase[] Requirement;

        /// <summary>
        /// Main skill
        /// </summary>
        public SkillBase Target;
    }
}
