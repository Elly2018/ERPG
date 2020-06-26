using UnityEditor;
using UnityEngine;

namespace ERPG
{
    [CustomEditor(typeof(Keypoint))]
    [CanEditMultipleObjects]
    public class KeypointEditor : Editor
    {
        private static GUIStyle style;

        private void OnSceneGUI()
        {
            if(style == null)
            {
                style = new GUIStyle();
                style.fontStyle = FontStyle.Bold;
                style.alignment = TextAnchor.MiddleCenter;
                style.fontSize = 15;
            }

            Keypoint kp = (Keypoint)target;
            Handles.Label(kp.transform.position + new Vector3(0, 0.5f, 0), kp.Keyword.ToString(), style);
        }
    }
}
