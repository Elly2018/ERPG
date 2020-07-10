namespace ERPGCore
{
    public class Creature
    {
        /// <summary>
        /// Check if the creature type is player type
        /// </summary>
        /// <param name="target">Creature target</param>
        /// <returns></returns>
        public static bool IsPlayer(CreatureBase target)
        {
            return target.GetType().IsSubclassOf(typeof(Player));
        }

        /// <summary>
        /// Check if the creature type is monster type
        /// </summary>
        /// <param name="target">Creature target</param>
        /// <returns></returns>
        public static bool IsMonster(CreatureBase target)
        {
            return target.GetType().IsSubclassOf(typeof(Monster));
        }

        /// <summary>
        /// Check if the creature type is NPC type
        /// </summary>
        /// <param name="target">Creature target</param>
        /// <returns></returns>
        public static bool IsNPC(CreatureBase target)
        {
            return target.GetType().IsSubclassOf(typeof(NonPlayerCharacter));
        }
    }
}
