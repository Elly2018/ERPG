using UnityEngine;

[AddComponentMenu("ERPG/UI/Player Info")]
[ExecuteAlways]
public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Vector2 size = new Vector2(600, 200);

    private void Update()
    {
        transform.GetComponent<RectTransform>().sizeDelta = size;
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(transform.GetComponent<RectTransform>().sizeDelta.x / 2f, transform.GetComponent<RectTransform>().sizeDelta.y / -2f);
    }
}

