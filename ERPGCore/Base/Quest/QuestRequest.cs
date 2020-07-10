namespace ERPGCore
{
    /// <summary>
    /// Request of the quest
    /// </summary>
    public abstract class QuestRequest
    {
        /// <summary>
        /// Display a line of text <br />
        /// Let user know if the quest is done
        /// </summary>
        /// <returns></returns>
        public abstract string Display();
        public abstract bool SatisfiedNeeds();
    }
}
