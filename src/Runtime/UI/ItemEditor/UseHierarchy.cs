namespace ERPG.Edit
{
    public class UseHierarchy : HierarchyBase
    {
        private Use[] list;

        private void Start()
        {
            list = GetAllInstance<Use>();
            foreach(var i in list)
            {
                SpawnCategory(i.ItemName.Category_Keyword);
                SpawnContent(i.ItemName.Category_Keyword, i.ItemName.Label_Keyword, i, ChangeContent);
            }
        }

        public void ChangeContent(object obj)
        {
            ContentPage.ShowUseInformation(obj as Use);
        }
    }
}
