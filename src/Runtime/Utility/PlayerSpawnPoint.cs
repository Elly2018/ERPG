using ERPG;
using UnityEngine;

[AddComponentMenu("ERPG/Player Spawn")]
public class PlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] private SearchTerm player;

    private void Start()
    {
        GameObject g = Manage.SpawnPlayer(player, transform.position);
        CPlayer cPlayer = g.AddComponent<CPlayer>();
    }
}
