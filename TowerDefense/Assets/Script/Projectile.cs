using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    [SerializeField] int minDamage;
    [SerializeField] int maxDamage;
    [SerializeField] float speed;
    [SerializeField] bool Burning;
    [SerializeField] bool Chilled;
    [SerializeField] bool AreaEffect;
    [SerializeField] Collider AreaEffectCollider;

    private float speedDebuff = 1;
    private int damageOverTime = 13;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        AreaEffectCollider.enabled = false;

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            // Check different projectile effects
            if (Burning)
            {
                ApplyBurningEffect();
            }
            else if (Chilled)
            {
                ApplyChilledEffect();
            }
            else if (AreaEffect)
            {
                ApplyAreaEffect();
            }
            else
            {
                ApplyNormalHit();
            }

            Destroy(gameObject);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void ApplyBurningEffect()
    {
        if (target != null)
        {
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamageOverTime(damageOverTime);
                ApplyNormalHit();
            }
        }
    }

    void ApplyChilledEffect()
    {
        if (target != null)
        {
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeChillDebuff(speedDebuff);
                ApplyNormalHit();
            }
        }
    }

    void ApplyAreaEffect()
    {
        AreaEffectCollider.enabled = true;
        ApplyNormalHit();
    }

    void ApplyNormalHit()
    {
        if (target != null)
        {
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                int damageAmount = Random.Range(minDamage, maxDamage);
                enemy.TakeDamage(damageAmount);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (AreaEffect)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                int damageAmount = Random.Range(minDamage, maxDamage);
                enemy.TakeDamage(damageAmount);
            }
        }
    }
}

