using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI Wave;
    [SerializeField] TextMeshProUGUI Gold;
    [SerializeField] TextMeshProUGUI Life;
    [SerializeField] Transform crystal;
    public Transform Crystal { get { return crystal; } }

    public float rounds = 1;
    public float gold = 500;
    public float life = 150;

	private void Awake()
	{
		instance = this; 
	}

    // Update is called once per frame
    void Update()
    {
        Wave.text = "Wave " + rounds;
        Gold.text = gold.ToString();
        Life.text = "Life: " + life + " /150";
    }

    public void ApplyDamageToCrystal(float damageAmount)
    {
        if (life <= 0)
        {

        }
        else
        {
            life -= damageAmount;
        }
    }
}
