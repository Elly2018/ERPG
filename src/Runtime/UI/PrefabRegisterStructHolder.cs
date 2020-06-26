using UnityEngine;

namespace ERPG
{
    /// <summary>
    /// Transfer prefab register object into scriptable object <br />
    /// Which is unity editor can read
    /// </summary>
    public class PrefabRegisterStructHolder : ScriptableObject
    {
        public PrefabRegisterStruct data;

        void OnEnable()
        {
            hideFlags = HideFlags.DontSave;
            if (data == null)
            {
                data = new PrefabRegisterStruct();
            }
        }
    }
}