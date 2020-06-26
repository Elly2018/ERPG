using ERPG;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("ERPG/Container/Player")]
public class CPlayer : MonoBehaviour
{
    private Player player;
    private NavMeshAgent agent;
    private Animator anim;

    private void RegisterPlayer(Player _player)
    {
        player = _player;
    }
}
