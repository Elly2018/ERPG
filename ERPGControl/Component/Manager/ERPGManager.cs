using UnityEngine;

namespace ERPGControl
{
    [AddComponentMenu("ERPG/Manager/Main")]
    public class ERPGManager : MonoBehaviour
    {
        [SerializeField] private SceneList scenelist = new SceneList();

        private void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}
