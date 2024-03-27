using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]

    public float range = 5f;
    public float fireRate;
    private float countdown = 0;

    bool placed = false;

    [SerializeField] Material towerMat;
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] public Transform firePos;
    [SerializeField] public Collider towCollider;

    private void Awake()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    public void Selected()
    {
        towerMat.color = Color.yellow;
    }

    public void Buildable()
    {
            towerMat.color = Color.green;
    }

    public void NonBuildable()
    {
            towerMat.color = Color.red;     
    }

    public void Build()
    {   
        placed = true;
        if(placed != false)
        {
            towerMat.color = Color.white;
        }
    }

    void UpdateTarget()
    {
        if(placed != false)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (Collider collider in colliders)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, collider.transform.position);
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = collider.gameObject;
                    }
                }
            }

            if (nearestEnemy != null)
            {
                target = nearestEnemy.transform;
                transform.LookAt(target.position);
            }
            else
            {
                target = null;
            }
        }

    }

    public void Shoot()
    {
        if(placed != false)
        {
            if (target != null)
            {
                if (countdown <= 0)
                {
                    GameObject projectileGameObj = (GameObject)Instantiate(projectilePrefab, firePos.position, firePos.rotation);
                    Projectile projectile = projectileGameObj.GetComponent<Projectile>();
                    if (projectile != null)
                    {
                        projectile.Seek(target);
                    }
                    countdown = 1f / fireRate;
                }
                countdown -= Time.deltaTime;
            }
        }
    }

     void Update()
    {
        if(placed != false)
        {
            if (target != null)
            {
                Shoot();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
