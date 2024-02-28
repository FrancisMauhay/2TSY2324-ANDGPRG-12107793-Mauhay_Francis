using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject car;
    [SerializeField] Collision border;

    public float timeValue = 30;
    public float lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            lives--;
        }

        if(timeValue <= 0 && lives >0)
        {
            RestartScene(1);
        }
        else if(lives <= 0)
        {

        }

        Display();
    }

    void Display()
    {
        timerText.text = "Timer: " + timeValue.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    private void OnCollisionEnter(Collision border)
    {
        timeValue = 30;
        lives--;
        RestartScene(1);
    }

    void RestartScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
