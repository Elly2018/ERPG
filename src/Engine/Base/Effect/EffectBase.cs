namespace ERPG
{
    /// <summary>
    /// Effect will change creature's properties <br />
    /// Such as heal or strength <br />
    /// And usually have countdown
    /// </summary>
    [System.Serializable]
    public abstract class EffectBase
    {
        /// <summary>
        /// Effect description
        /// </summary>
        public abstract SearchTerm EffectDescription();

        /// <summary>
        /// Define the effect duration <br />
        /// If it's -1 then it is permanent exist
        /// </summary>
        public int CountDown;

        /// <summary>
        /// Trigger every second
        /// </summary>
        /// <param name="target">Creature target</param>
        public abstract void EachSecond(CreatureBase target);
    }
}
