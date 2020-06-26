using UnityEngine;

namespace ERPG
{
    [AddComponentMenu("ERPG/Key Point")]
    public class Keypoint : MonoBehaviour
    {
        [SerializeField] public SearchTerm Keyword;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.HSVToRGB(0.5f, 1.0f, 1.0f, true);
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
    }
}
