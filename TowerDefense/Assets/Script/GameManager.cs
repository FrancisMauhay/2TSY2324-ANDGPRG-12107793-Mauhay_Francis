using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI Wave;
    [SerializeField] Transform crystal;
    public Transform Crystal { get { return crystal; } }

    public int rounds = 1;

	private void Awake()
	{
		instance = this; 
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rounds);
        Wave.text = "Wave " + rounds;
    }
}
