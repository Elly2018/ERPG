using UnityEngine;
using UnityEngine.SceneManagement;

namespace ERPGControl
{
    [System.Serializable]
    public class SceneList
    {
        public enum SceneType
        {
            Initialize
        }

        [Tooltip("First scene will popup when game start\n" +
            "handle network check, loading resource\n" +
            "language file, mods, confliect test\n" +
            "Detail see docs page initialize")]
        public Object Initialization;

        public Object Title;

        public Object Ingame;

        public void LoadScene(SceneType type)
        {
            switch (type)
            {
                case SceneType.Initialize:
                    SceneManager.LoadScene(Initialization.name);
                    break;
            }
        }
    }
}
