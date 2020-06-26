using System;
using UnityEngine;
using UnityEngine.UI;

namespace ERPG.Edit
{
    /// <summary>
    /// Simply change dropdown content and make it display item type elements
    /// </summary>
    public class TypeDropdown : MonoBehaviour
    {
        private Tuple<System.Type, string>[] display;

        void Start()
        {
            Dropdown dd = GetComponent<Dropdown>();
            if (!dd) return;

            display = ItemEditor.GetDisplayItems();

            dd.ClearOptions();
            foreach(var i in display)
            {
                dd.options.Add(new Dropdown.OptionData() { text = i.Item2 });
            }

            dd.value = 1;
            dd.value = 0;
        }

        /// <summary>
        /// What type is selected right now
        /// </summary>
        /// <returns></returns>
        public Type CurrentType()
        {
            Dropdown dd = GetComponent<Dropdown>();
            if (!dd) return null;

            return display[dd.value].Item1;
        }
    }
}