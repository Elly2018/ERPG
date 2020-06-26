using System;
using UnityEngine;

namespace ERPG.Edit
{
    /// <summary>
    /// The page manager for item editor <br />
    /// Default 0 is selection title page
    /// </summary>
    public class ItemEditorPageManager : PageManager
    {
        /// <summary>
        /// The object that define what type is selecting
        /// </summary>
        [SerializeField] private TypeDropdown Selection;

        private void Start()
        {
            ChangePage(0);
        }

        /// <summary>
        /// Depend on type selected, change page
        /// </summary>
        public void SelectionConfirmPressed()
        {
            Type select = Selection.CurrentType();
            foreach(var i in Pages)
            {
                if (select.Name.Contains(i.gameObject.name))
                {
                    TurnOffAllPage();
                    i.gameObject.SetActive(true);
                    return;
                }
            }
        }

        /// <summary>
        /// Back to first page
        /// </summary>
        public void BackToSelectionPage()
        {
            ChangePage(0);
        }
    }
}
