#if UNITY_EDITOR
using UnityEditor;

namespace ERPGControl.UI
{
    [CustomEditor(typeof(Initialize))]
    public class InitializeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
#endif