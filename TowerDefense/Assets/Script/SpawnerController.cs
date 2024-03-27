using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
	public static SpawnerController instance;
	[SerializeField] Transform spawnPoint;
	[SerializeField] GameObject[] enemyPrefab;

	[SerializeField] List<GameObject> enemyList;
	[SerializeField] float damage;

	public int [] EnemyRoundCount;
	private int CountCheck = 0;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		for (int i = 0; i < EnemyRoundCount[CountCheck]; i++) 
		{ 
			SpawnEnemy(0);
		}
	}

	public void WaveIncrease()
	{
		CountCheck++;
		GameManager.instance.rounds++;
		for (int i = 0; i < EnemyRoundCount[CountCheck]; i++)
        {
			SpawnEnemy(0);
        }

	}

	public void SpawnEnemy(int enemyIdx)
	{
		GameObject enemyObj = (GameObject)Instantiate(enemyPrefab[enemyIdx], spawnPoint.position, Quaternion.identity);
		enemyObj.GetComponent<Enemy>().SetTarget(GameManager.instance.Crystal);
		enemyList.Add(enemyObj);

		Debug.Log(enemyList.Count);
	}

	public void RemoveEnemy(GameObject obj) 
	{
		enemyList.Remove(obj);
		ListCheck();
	}

	private void ListCheck ()
    {
		if(enemyList.Count <= 0)
        {
			WaveIncrease();
        }
    }
}
