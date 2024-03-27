using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;

    Ray ray;
    [SerializeField] RaycastHit hit;

    [SerializeField] Tower SelectedTower;
    [SerializeField] public List<Tower> TowerList;

    private void Awake()
    {
        instance = this;
    }

    public void OnSelect()
    {
        SelectedTower.Selected();
        Debug.Log("Tower Selected");
    }

    public void UpgradeDamage()
    {
       Projectile projectile = GetComponent<Projectile>();
       if(GameManager.instance.gold < GameManager.instance.damageUpgradeCost)
        {
            return;
        }
       else if(GameManager.instance.gold >= GameManager.instance.damageUpgradeCost)
        {
            GameManager.instance.tierDamage++;
            projectile.maxDamage += 1;
            projectile.minDamage += 1;    
        }
    }

    public void UpgradeFirerate()
    {
        
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && IsTowerSelectionCollider(hit.collider))
            {
                Tower towerComponent = hit.collider.GetComponentInParent<Tower>();

                if (towerComponent != null)
                {
                    SelectedTower = towerComponent;
                    OnSelect();
                    Debug.Log("Tower Selected: " + SelectedTower.name);
                }
            }
        }
    }

    bool IsTowerSelectionCollider(Collider collider)
    {
        return collider is BoxCollider && collider.transform.parent != null && collider.transform.parent.GetComponent<Tower>() != null;
    }
}
 