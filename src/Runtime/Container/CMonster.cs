using ERPG;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("ERPG/Container/Monster")]
public class CMonster : MonoBehaviour
{
    private Monster monster;
    private NavMeshAgent agent;
    private Animator anim;

    public void RegisterMonster(Monster _monster, ZoneCommand zoneCommand)
    {
        monster = _monster;

        anim = GetComponent<Animator>();
        if (anim)
        {
            monster.Animation = new AnimationCommand()
            {
                SetBool = anim.SetBool,
                SetInt = anim.SetInteger,
                SetFloat = anim.SetFloat,

                GetBool = anim.GetBool,
                GetInt = anim.GetInteger,
                GetFloat = anim.GetFloat,

                SetToggle = anim.SetTrigger,
                ResetToggle = anim.ResetTrigger,

            };
        }

        agent = GetComponent<NavMeshAgent>();
        if (agent)
        {
            monster.PathFinder = new PathFindingCommand()
            {
                Move = this.Move,
                IsMoving = this.IsMoving,
                Distance = GetDistance,
            };
        }

        monster.GetPosition = GetPos;

        monster.zone = zoneCommand;

        monster.Spawn();
    }

    private void Update()
    {
        monster.Update(Time.deltaTime);
    }

    private void OnDestroy()
    {
        monster.Death();
    }

    private Vec3 GetPos()
    {
        return new Vec3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Move(Vec3 position)
    {
        if (agent.isOnNavMesh)
        {
            Vector3 b = new Vector3(position.x, position.y + 999f, position.z);
            Ray ray = new Ray(b, Vector3.down);
            RaycastHit[] hit;
            hit = Physics.RaycastAll(ray);

            foreach (var i in hit)
            {
                if (LayerMask.LayerToName(i.transform.gameObject.layer) == "Terrain")
                {
                    agent.SetDestination(i.point);
                    return;
                }
            }
        }
    }

    private bool IsMoving()
    {
        return !agent.isStopped;
    }

    private float GetDistance(Vec3 position)
    {
        if (agent.isOnNavMesh)
        {
            Vector3 b = new Vector3(position.x, position.y + 999f, position.z);
            Ray ray = new Ray(b, Vector3.down);
            RaycastHit[] hit;
            hit = Physics.RaycastAll(ray);

            foreach (var i in hit)
            {
                if (LayerMask.LayerToName(i.transform.gameObject.layer) == "Terrain")
                {
                    return Vector3.Distance(new Vector3(i.point.x, i.point.y, i.point.z), transform.position);
                }
            }
        }
        return -1.0f;
    }
}
