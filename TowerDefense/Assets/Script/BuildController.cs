using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildController : MonoBehaviour
{
    public static BuildController instance;
    [SerializeField] float buildableOffsetY = 2;
    Ray ray;
    [SerializeField] RaycastHit hit;

    [SerializeField] GameObject[] Towers;
    [SerializeField] GameObject draggableTower;
    [SerializeField] Tower tempTwr;

    private void Awake()
    {
        instance = this;
    }
    public void SpawnCrossbow()
    {
        if (GameManager.instance.gold < 100)
        {
            Debug.Log("Not enough gold");
        }
        else
        {
            GameObject tempTwrObj = (GameObject)Instantiate(Towers[0]);
            draggableTower = tempTwrObj;
            tempTwr = tempTwrObj.GetComponent<Tower>();
            GameManager.instance.gold -= 100;
        }
    }

    public void SpawnIceTower()
    {
        if (GameManager.instance.gold < 500)
        {
            Debug.Log("Not enough gold");
        }
        else
        {
            GameObject tempTwrObj = (GameObject)Instantiate(Towers[2]);
            draggableTower = tempTwrObj;
            tempTwr = tempTwrObj.GetComponent<Tower>();
            GameManager.instance.gold -= 500;
        }
    }

    public void SpawnFireTower()
    {
        if (GameManager.instance.gold < 500)
        {
            Debug.Log("Not enough gold");
        }
        else
        {
            GameObject tempTwrObj = (GameObject)Instantiate(Towers[3]);
            draggableTower = tempTwrObj;
            tempTwr = tempTwrObj.GetComponent<Tower>();
            GameManager.instance.gold -= 500;
        }
    }

    public void SpawnCannonTower()
    {
        if (GameManager.instance.gold < 200)
        {
            Debug.Log("Not enough gold");
        }
        else
        {
            GameObject tempTwrObj = (GameObject)Instantiate(Towers[1]);
            draggableTower = tempTwrObj;
            tempTwr = tempTwrObj.GetComponent<Tower>();
            GameManager.instance.gold -= 200;
        }
    }

    Vector3 SnapToGrid(Vector3 towerPos)
    {
        return new Vector3(Mathf.Round(towerPos.x), towerPos.y, Mathf.Round(towerPos.z));
    }

    void Update()
    {
        
        if(draggableTower != null)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                draggableTower.transform.position = SnapToGrid(hit.point);
                if(hit.point.y < buildableOffsetY)
                {
                    tempTwr.NonBuildable();
                }
                else
                {
                    tempTwr.Buildable();
                    if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                    {
                        tempTwr.Build();
                        TowerManager.instance.TowerList.Add(tempTwr);
                        draggableTower = null;  
                    }
                }
            }
        }
        
    }
}
