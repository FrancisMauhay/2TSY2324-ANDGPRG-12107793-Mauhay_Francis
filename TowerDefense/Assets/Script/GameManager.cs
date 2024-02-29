using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    }
}
