using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

namespace ERPG
{
    public class ItemContentPage : MonoBehaviour
    {
        [SerializeField] private RawImage Icon;
        [SerializeField] private Text Title;
        [SerializeField] private Text Description;

        public void ShowUseInformation(Use obj)
        {
            PrefabRegisterStruct pgs = PrefabRegisterStruct.GetPrefabRegisterStruct().data;
            SearchTerm st = new SearchTerm(obj.GetType().GetAttribute<SearchKeyword>());
            foreach (var i in pgs.ItemsRegister.Use)
            {
                Debug.Log(i.transform.name);
                PrefabRegister pr = i.GetComponent<PrefabRegister>();
                if (pr && pr.Keyword == st)
                {
                    Icon.texture = pr.Icon;
                    Title.text = "Item Name: " + pr.Keyword.Label_Keyword;

                    return;
                }
            }
            Debug.LogWarning($"Cannot find prefab object according to keyword this object have \nCategory: {st.Category_Keyword} \nLabel: {st.Label_Keyword}");
        }
    }
}
