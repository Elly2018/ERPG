using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("ERPG/UI/SkillSet")]
[ExecuteAlways]
public class SkillSetUI : MonoBehaviour
{
    public enum SkillSetType
    {
        Num, Ctrl, Alt
    }

    [SerializeField] private float size;
    [SerializeField] private string Prefix;
    [SerializeField] private SkillSetType setType;

    public void SetSize(float _size) => size = _size;

    private void Update()
    {
        HorizontalLayoutGroup hlg = GetComponent<HorizontalLayoutGroup>();
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
            transform.GetChild(i).GetComponentInChildren<Text>().text = Prefix + (i + 1).ToString();
        }

        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(
            hlg.spacing * transform.childCount + hlg.padding.left + hlg.padding.right + transform.childCount * size,
            hlg.padding.top + hlg.padding.bottom + size);
    }
}
