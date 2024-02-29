using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
	public static SpawnerController instance;
	[SerializeField] Transform spawnPoint;
	[SerializeField] GameObject[] enemyPrefab;

	[SerializeField] List<GameObject> enemyList;

	private int EnemyCount;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		for (int i = 0; i < 5; i++) 
		{ 
			SpawnEnemy(0);
		}
	}

	public void WaveIncrease()
	{
		/*if(EnemyCount <= 0)
        {
			for(int i = 0; i < )
        }*/
	}

	public void SpawnEnemy(int enemyIdx)
	{
		GameObject enemyObj = (GameObject)Instantiate(enemyPrefab[enemyIdx]);
		enemyObj.transform.position = spawnPoint.position;
		enemyObj.GetComponent<Enemy>().SetTarget(GameManager.instance.Crystal);
		enemyList.Add(enemyObj);


		Debug.Log(enemyList.Count);
	}

	private void RemoveEnemy(GameObject obj)
	{
		enemyList.Remove(obj);
	}
}
