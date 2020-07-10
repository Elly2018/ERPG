using System;

namespace ERPGCore
{
    /// <summary>
    /// handler connect with unity component that define the zone
    /// </summary>
    public class ZoneCommand
    {
        /// <summary>
        /// Zone position
        /// </summary>
        public Func<Vec3> ZonePosition;

        /// <summary>
        /// Zone radius
        /// </summary>
        public Func<float> ZoneRadius;

        /// <summary>
        /// Get random position in zone
        /// </summary>
        public Func<Vec3> RandomPositionInZone;
    }
}
