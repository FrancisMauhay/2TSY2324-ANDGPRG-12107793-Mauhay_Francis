using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarManager : MonoBehaviour
{
    [SerializeField] public GameObject SpawnPoint;
    private float lives = 5;

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        if(lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        lives--;
        Respawn();
    }


}