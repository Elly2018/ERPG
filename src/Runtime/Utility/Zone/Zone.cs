using UnityEngine;

namespace ERPG
{
    public abstract class Zone : MonoBehaviour
    {
        [Header("Zone Setting")]
        [SerializeField] public float Radius = 2.0f;
    }
}
