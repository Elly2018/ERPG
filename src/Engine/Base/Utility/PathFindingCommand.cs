using System;

namespace ERPG
{
    /// <summary>
    /// The path finder connection with unity navigation system
    /// </summary>
    public class PathFindingCommand
    {
        /// <summary>
        /// Moving
        /// </summary>
        public Action<Vec3> Move;

        /// <summary>
        /// 
        /// </summary>
        public Func<bool> IsMoving;

        /// <summary>
        /// 
        /// </summary>
        public Func<Vec3, float> Distance;
    }
}
