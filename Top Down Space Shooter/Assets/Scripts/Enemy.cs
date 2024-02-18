using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] TextMeshProUGUI healthText;

    public EnemySpawnerHandler Handler { get; set; }

    float curHealth = 100;
    float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
        HealthUpdate();
    }

    // Update is called once per frame
    void Update()
    {
     
        this.transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
        HealthUpdate();
    }

    void HealthUpdate()
    {
        healthText.text = curHealth + "/" + maxHealth;
    }

    void takeDamage()
    {
        curHealth -= 10;
        if(curHealth <= 0)
        {
            
            Handler.EnemyDied(this.gameObject);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bulletScript bullet = other.gameObject.GetComponent<bulletScript>();

        if (bullet != null)
        {
            Debug.Log("Dead");
            Destroy(other.gameObject);
            takeDamage();
        }
        else
        {
            Debug.Log("Try Again");
            return;
        }
    }
}
