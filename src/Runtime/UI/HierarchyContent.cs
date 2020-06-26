using System;
using UnityEngine;
using UnityEngine.UI;

namespace ERPG.Edit
{
    public class HierarchyContent : MonoBehaviour
    {
        /// <summary>
        /// The text that show on UI display
        /// </summary>
        [SerializeField] public Text contentName;

        /// <summary>
        /// Data
        /// </summary>
        public object content;

        /// <summary>
        /// The event that call when button is pressed
        /// </summary>
        private Action<object> clickEvent;

        /// <summary>
        /// Register click event
        /// </summary>
        /// <param name="click"></param>
        public void Register(Action<object> click)
        {
            clickEvent = click;
            Button b = GetComponent<Button>();
            if (b) b.onClick.AddListener(ButtonPressed);
        }

        /// <summary>
        /// Button press event
        /// </summary>
        public void ButtonPressed()
        {
            clickEvent.Invoke(content);
        }
    }
}
