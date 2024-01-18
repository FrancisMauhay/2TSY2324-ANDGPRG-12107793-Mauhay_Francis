using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    public Text textInfo;

    // Start is called before the first frame update
    void Start()
    {
        textInfo.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sun"))
        {
            textInfo.text = "Sun";
            textInfo.gameObject.SetActive(true);            
        }
        if (other.CompareTag("Mercury"))
        {
            textInfo.text = "Mercury";
            textInfo.gameObject.SetActive(true);
        }
        if (other.CompareTag("Venus"))
        {
            textInfo.text = "Venus";
            textInfo.gameObject.SetActive(true);
        }
        if (other.CompareTag("Earth"))
        {
            textInfo.text = "Earth";
            textInfo.gameObject.SetActive(true);
        }
        if (other.CompareTag("Mars"))
        {
            textInfo.text = "Mars";
            textInfo.gameObject.SetActive(true);
        }
        if (other.CompareTag("Jupiter"))
        {
            textInfo.text = "Jupiter";
            textInfo.gameObject.SetActive(true);
        }
        if (other.CompareTag("Saturn"))
        {
            textInfo.text = "Saturn";
            textInfo.gameObject.SetActive(true);
        }
        if (other.CompareTag("Uranus"))
        {
            textInfo.text = "Uranus";
            textInfo.gameObject.SetActive(true);
        }
        if (other.CompareTag("Neptune"))
        {
            textInfo.text = "Neptune";
            textInfo.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sun"))
        {
            textInfo.gameObject.SetActive(false);
        }
        if (other.CompareTag("Mercury"))
        {
            textInfo.gameObject.SetActive(false);
        }
        if (other.CompareTag("Venus"))
        {
            textInfo.gameObject.SetActive(false);
        }
        if (other.CompareTag("Earth"))
        {
            textInfo.gameObject.SetActive(false);
        }
        if (other.CompareTag("Mars"))
        {
            textInfo.gameObject.SetActive(false);
        }
        if (other.CompareTag("Jupiter"))
        {
            textInfo.gameObject.SetActive(false);
        }
        if (other.CompareTag("Saturn"))
        {
            textInfo.gameObject.SetActive(false);
        }
        if (other.CompareTag("Uranus"))
        {
            textInfo.gameObject.SetActive(false);
        }
        if (other.CompareTag("Neptune"))
        {
            textInfo.gameObject.SetActive(false);
        }
    }
}