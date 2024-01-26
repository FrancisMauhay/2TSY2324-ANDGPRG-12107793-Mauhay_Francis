using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] TextMeshProUGUI healthText;
/*    [SerializeField] public GameObject enemyPrefab;

    private float x = 0;
    private float spawnCount = 0;*/

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
        
       /* if(spawnCount == 0)
        {
            spawn();
            spawnCount++;
        }*/
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
            Destroy(this.gameObject);

            /*spawnCount --;*/
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

/*    void spawn()
    {
        x = Random.Range(-5, 5);

        GameObject Enemy = Instantiate(enemyPrefab) as GameObject;
        Enemy.transform.position = new Vector3(x, 10, 0);
    }*/
}
