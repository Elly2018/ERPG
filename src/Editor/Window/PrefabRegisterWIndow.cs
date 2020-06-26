using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Linq;

namespace ERPG
{
    /// <summary>
    /// The window let user create, modify, remove the prefab register list
    /// </summary>
    public class PrefabRegisterWindow : EditorWindow
    {
        private PrefabRegisterStructHolder Test;
        private SerializedObject m_serializedObject;
        private SerializedProperty m_serializedProperty;
        private Vector2 m_scrollPos = new Vector2(0, 0);

        [MenuItem("ERPG/Prefab Register Window")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            PrefabRegisterWindow window = (PrefabRegisterWindow)EditorWindow.GetWindow(typeof(PrefabRegisterWindow));
            window.titleContent = new GUIContent("Prefab Register Window");
            window.Show();
        }

        private void OnEnable()
        {
            PrefabRegisterStructHolder tmp = Resources.Load<PrefabRegisterStructHolder>("prefabregister");

            if (tmp != null)
            {
                Test = tmp;
            }
            else
            {
                Test = ScriptableObject.CreateInstance<PrefabRegisterStructHolder>();
                Test.hideFlags = HideFlags.None;
                if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                    AssetDatabase.CreateFolder("Assets", "Resources");
                AssetDatabase.CreateAsset(Test, "Assets/Resources/prefabregister.asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            if (m_serializedObject == null)
            {
                m_serializedObject = new SerializedObject(Test);
                m_serializedProperty = m_serializedObject.FindProperty("data");
            }
        }

        private void OnGUI()
        {
            //Init();
            m_serializedObject.Update();
            EditorGUILayout.BeginVertical();
            m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos, GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.Height(position.height));

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(m_serializedProperty, true);
            if (EditorGUI.EndChangeCheck())
            {
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            m_serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();
        }
    }
}