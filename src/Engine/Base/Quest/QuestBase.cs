namespace ERPG
{
    [System.Serializable]
    public abstract class QuestBase
    {
        /// <summary>
        /// Quest description
        /// </summary>
        public abstract SearchTerm QuestDescription();

        /// <summary>
        /// Check if target player can see the quest yet <br />
        /// Usually quest have some of the limitation <br />
        /// Such as level.. progress.. etc..
        /// </summary>
        /// <param name="target">Player target</param>
        /// <returns></returns>
        public abstract bool CanTake(Player target);

        /// <summary>
        /// When quest is token by player
        /// </summary>
        public abstract void Token(Player target);

        /// <summary>
        /// When quest is abandon by player
        /// </summary>
        /// <param name="target"></param>
        public abstract void Abandon(Player target);

        /// <summary>
        /// When quest is finish by player
        /// </summary>
        /// <param name="target"></param>
        public abstract void Finish(Player target);
    }
}
