using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("ERPG/UI/System Button List")]
[ExecuteAlways]
public class SystemButtonList : MonoBehaviour
{
    [SerializeField] private float size;

    private void Update()
    {
        HorizontalLayoutGroup hlg = GetComponent<HorizontalLayoutGroup>();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
        }

        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(
            hlg.spacing * transform.childCount + hlg.padding.left + hlg.padding.right + transform.childCount * size,
            hlg.padding.top + hlg.padding.bottom + size);

        transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(transform.GetComponent<RectTransform>().sizeDelta.x / -2f, transform.GetComponent<RectTransform>().sizeDelta.y / 2f);
    }
}
