using UnityEngine;

namespace ERPG.Edit
{
    public abstract class PageManager : MonoBehaviour
    {
        [SerializeField] protected RectTransform[] Pages;

        public void ChangePage(int index)
        {
            TurnOffAllPage();
            Pages[index].gameObject.SetActive(true);
        }

        public void TurnOffAllPage()
        {
            foreach (var i in Pages)
                i.gameObject.SetActive(false);
        }
    }
}
