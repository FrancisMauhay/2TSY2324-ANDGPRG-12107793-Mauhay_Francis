using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] GameObject bullet1;
    [SerializeField] GameObject bullet2;
    [SerializeField] GameObject bullet3;
    [SerializeField] GameObject bullet4;

    private GameObject currentBullet;

    // Start is called before the first frame update
    void Start()
    {
        currentBullet = bullet1;
    }

    // Update is called once per frame
    void Update()
    {
        movementControls();
        playerShoot();
    }

    void movementControls()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            Debug.Log("Forward");
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
            Debug.Log("Back");
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            Debug.Log("Left");
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            Debug.Log("Right");
        }
    }

    void playerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBullet = bullet1; 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBullet = bullet2; 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentBullet = bullet3; 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentBullet = bullet4; 
        }

        if (currentBullet != null && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletObj = Instantiate(currentBullet) as GameObject;
            bulletObj.transform.position = this.transform.position;

            Destroy(bulletObj, 3);
        }
    }
}

