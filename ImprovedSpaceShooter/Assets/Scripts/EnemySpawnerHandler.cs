using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerHandler : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] AudioSource DestroySFX;

    private float x = 0;
    private float spawnCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (spawnCount == 0)
        {
            spawn();
            spawnCount++;
        }       
    }

    void spawn()
    {
        x = Random.Range(-2, 2);

        GameObject Enemy = Instantiate(enemyPrefab) as GameObject;
        Enemy.transform.position = new Vector3(x, 5, 0);
        Enemy.GetComponent<Enemy>().Handler = this;
    }

    public void EnemyDied(GameObject enemyObj)
    {
        Destroy(enemyObj);
        DestroySFX.Play();
        spawnCount--;
    }
}
