using System;

namespace ERPG
{
    /// <summary>
    /// Event handler connected with unity animator function
    /// </summary>
    [System.Serializable]
    public class AnimationCommand
    {
        /// <summary>
        /// ID, value
        /// </summary>
        public Action<string, bool> SetBool;

        /// <summary>
        /// ID, value
        /// </summary>
        public Action<string, float> SetFloat;

        /// <summary>
        /// ID, value
        /// </summary>
        public Action<string, int> SetInt;

        /// <summary>
        /// ID, Result
        /// </summary>
        public Func<string, bool> GetBool;

        /// <summary>
        /// ID, Result
        /// </summary>
        public Func<string, float> GetFloat;

        /// <summary>
        /// ID, Result
        /// </summary>
        public Func<string, int> GetInt;

        /// <summary>
        /// ID
        /// </summary>
        public Action<string> SetToggle;

        /// <summary>
        /// ID
        /// </summary>
        public Action<string> ResetToggle;
    }
}
