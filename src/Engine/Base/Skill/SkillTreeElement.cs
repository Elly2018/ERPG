using System;

namespace ERPG
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
        public Tuple<Type, int>[] requirement_level;

        /// <summary>
        /// Main skill
        /// </summary>
        public SkillBase target;
    }
}
