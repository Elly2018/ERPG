#if UNITY_EDITOR
using UnityEditor;

namespace ERPGControl
{
    [CustomEditor(typeof(ERPGManager))]
    public class ERPGManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            string message = 
@"
Main manager handle scene stage.
Record application status.
";
            EditorGUILayout.HelpBox(message, MessageType.Info);
        }
    }
}
#endif