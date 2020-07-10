namespace ERPGCore
{
    public class SkillInformationPack
    {
        /// <summary>
        /// How much time cost to let the skill active to finish
        /// </summary>
        public float Duration;

        /// <summary>
        /// How much time cost to re-use to skill again
        /// </summary>
        public float Colddown;

        /// <summary>
        /// How much time cost does this skill to charge
        /// </summary>
        public float ActiveTime;

        /// <summary>
        /// The addition for status
        /// </summary>
        public PropertiesAdditionList Addition;

        /// <summary>
        /// The properties for skill itself
        /// </summary>
        public PropertiesList properties;
    }
}
