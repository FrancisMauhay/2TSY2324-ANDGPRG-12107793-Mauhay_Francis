using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterType
{
    Flying,
    Ground,
}

public class Enemy : MonoBehaviour
{
    SpawnerController spawner;
    GameManager GM;

    [SerializeField] NavMeshAgent agent;

    [SerializeField] MonsterType type;
    public MonsterType MonsterType { get { return type; } }

    [SerializeField] Transform target;
   
    // Start is called before the first frame update
    void Awake()
    {
        this.agent = GetComponent<NavMeshAgent>();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
		this.agent.SetDestination(target.position);
        Debug.Log(this.agent.pathStatus);
	}

    public void OnTriggerEnter(Collider other)
    {
        GM.rounds++;
        Destroy(this);
    }
}
