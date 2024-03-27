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
    [SerializeField] TextMeshProUGUI Cost1;
    [SerializeField] TextMeshProUGUI Cost2;
    [SerializeField] Transform crystal;
    public Transform Crystal { get { return crystal; } }

    public float rounds = 1;
    public float gold = 500;
    public float life = 150;
    public float damageUpgradeCost = 100;
    public float firerateUpgradeCost = 100;
    public float tierDamage = 1;
    public float tierRate = 1;

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
        DamageTierCheck();
        FireRateTierCheck();
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

    public void DamageTierCheck()
    {
        if(tierDamage == 1)
        {
            Cost1.text = "Cost: " + 100.ToString();
            damageUpgradeCost = 100;
        }
        else if (tierDamage == 2)
        {
            Cost1.text = "Cost: " + 250.ToString();
            damageUpgradeCost = 250;
        }
        else if (tierDamage == 3)
        {
            Cost1.text = "Cost: " + 500.ToString();
            damageUpgradeCost = 500;
        }
        else if (tierDamage == 4)
        {
            Cost1.text = "Cost: " + 1000.ToString();
            damageUpgradeCost = 1000;
        }
        else if (tierDamage == 5)
        {
            Cost1.text = "Cost: " + 2000.ToString();
            damageUpgradeCost = 2000;
        }
    }

    public void FireRateTierCheck()
    {
        if (tierRate == 1)
        {
            Cost2.text = "Cost: " + 100.ToString();
            damageUpgradeCost = 100;
        }
        else if (tierRate == 2)
        {
            Cost2.text = "Cost: " + 250.ToString();
            damageUpgradeCost = 250;
        }
        else if (tierRate == 3)
        {
            Cost2.text = "Cost: " + 500.ToString();
            damageUpgradeCost = 500;
        }
        else if (tierRate == 4)
        {
            Cost2.text = "Cost: " + 1000.ToString();
            damageUpgradeCost = 1000;
        }
        else if (tierRate == 5)
        {
            Cost2.text = "Cost: " + 2000.ToString();
            damageUpgradeCost = 2000;
        }
    }
}
