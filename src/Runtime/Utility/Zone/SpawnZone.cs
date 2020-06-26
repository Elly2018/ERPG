using System;
using System.Collections.Generic;
using UnityEngine;

namespace ERPG
{
    [AddComponentMenu("ERPG/Zone/Spawn")]
    public class SpawnZone : Zone
    {
        [Header("Spawn Setting")]
        [SerializeField] public SearchTerm[] Monsters;
        [SerializeField] public float SpawnRadius;
        [SerializeField] public string Layer;
        [SerializeField] public int Maximum = -1;
        [SerializeField] public Counter SpawnDelay;

        private List<Monster> monsters = new List<Monster>();

        private void OnDrawGizmos()
        {
            Vector3 pos = transform.position;
            Gizmos.color = new Color(1, 1, 1);
            Gizmos.DrawWireSphere(pos, Radius);
            Gizmos.color = new Color(0, 1, 0);
            Gizmos.DrawWireSphere(pos, SpawnRadius);
        }

        private void Start()
        {
            SpawnDelay.TimeUp = Spawn;
        }

        private void Update()
        {
            if (Maximum == -1 || monsters.Count < Maximum)
                SpawnDelay.Update(Time.deltaTime);
        }

        private void Spawn()
        {
            Vector3 pos = transform.position;
            Vector3 position = pos += new Vector3(0, 500, 0);
            UnityEngine.Random.InitState(DateTime.Now.Second + DateTime.Now.Millisecond);
            position += new Vector3(Mathf.Cos(UnityEngine.Random.Range(-360, 360)) * SpawnRadius, 0, Mathf.Sin(UnityEngine.Random.Range(-360, 360)) * SpawnRadius);

            Ray ray = new Ray(position, Vector3.down);
            RaycastHit[] hit;

            hit = Physics.RaycastAll(ray);

            foreach(var i in hit)
            {
                if (i.transform.gameObject.layer == LayerMask.NameToLayer(Layer))
                {
                    GameObject g = Manage.SpawnMonster(Monsters[0], i.point);
                    CMonster m = g.AddComponent<CMonster>();
                    Monster mm = Monster.GetMonsterInstance(Monsters[0]);
                    m.RegisterMonster(mm, new ZoneCommand() { 
                        ZonePosition = GetPosition,
                        ZoneRadius = GetRadius,
                        RandomPositionInZone = GetRandomPosition,
                    });
                    monsters.Add(mm);
                    return;
                }
            }
        }

        public void MonsterDeath(Monster target)
        {
            monsters.Remove(target);
        }

        private Vec3 GetPosition()
        {
            Vector3 pos = transform.position;
            return new Vec3(pos.x, pos.y, pos.z);
        }

        private Vec3 GetRandomPosition()
        {
            Vector3 pos = transform.position;
            Vector3 position = pos += new Vector3(0, 500, 0);
            UnityEngine.Random.InitState(DateTime.Now.Second + DateTime.Now.Millisecond);
            position += new Vector3(Mathf.Cos(UnityEngine.Random.Range(-360, 360)) * SpawnRadius, 0, Mathf.Sin(UnityEngine.Random.Range(-360, 360)) * SpawnRadius);
            return new Vec3(position.x, position.y, position.z);
        }

        private float GetRadius()
        {
            return Radius;
        }
    }
}
