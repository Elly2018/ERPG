using UnityEngine;

namespace ERPGControl.UI
{
    public abstract class SceneUIBase : MonoBehaviour
    {

        public virtual void Start()
        {
            BuildPage();
        }

        /// <summary>
        /// Start will called this function <br />
        /// Put the UI initialize code here
        /// </summary>
        public abstract void BuildPage();
    }
}
