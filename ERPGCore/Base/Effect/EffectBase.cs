namespace ERPGCore
{
    /// <summary>
    /// Effect will change creature's properties <br />
    /// Such as heal or strength <br />
    /// And usually have countdown
    /// </summary>
    [System.Serializable]
    public abstract class EffectBase : EObject
    {
        /// <summary>
        /// Define the effect duration <br />
        /// If it's -1 then it is permanent exist
        /// </summary>
        public int CountDown;

        /// <summary>
        /// The properties this effect have
        /// </summary>
        public PropertiesAdditionList properties;

        /// <summary>
        /// Trigger every second
        /// </summary>
        /// <param name="target">Creature target</param>
        public abstract void EachSecond(CreatureBase target);
    }
}
