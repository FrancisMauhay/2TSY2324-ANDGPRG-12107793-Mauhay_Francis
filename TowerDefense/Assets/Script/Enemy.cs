using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterType
{
    Flying,
    Ground,
    Boss,
}

public class Enemy : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;

    [SerializeField] MonsterType type;
    [SerializeField] float damage;
    [SerializeField] float health;

    private float timer = 5;
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

    public void DamageOnCrystal(float _damage)
    {
        GameManager.instance.ApplyDamageToCrystal(_damage);
    }

    public void TakeDamage(float damageFromProjectile)
    {
        health -= damageFromProjectile;
        if (health<=0)
        {
            SpawnerController.instance.RemoveEnemy(this.gameObject);
            GameManager.instance.gold += 20;
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        DamageOnCrystal(damage);
        SpawnerController.instance.RemoveEnemy(this.gameObject);
        Destroy(this.gameObject);     
    }

    public void TakeChillDebuff(float speedDebuff)
    {
        if(timer <= 0)
        {
            this.agent.speed += speedDebuff;
            return;
        }
        else
        {
            timer -= Time.deltaTime;
            this.agent.speed -= speedDebuff;
        }
    }
    public void TakeDamageOverTime(float damageOverTime)
    {
        if(timer <= 0)
        {
            return;
        }
        else
        {
            timer -= Time.deltaTime;
            health -= damageOverTime * Time.deltaTime;
            Debug.Log("health: " + health);
        }

    }

    private void Update()
    {
        Debug.Log("health: " + health);
    }
}
