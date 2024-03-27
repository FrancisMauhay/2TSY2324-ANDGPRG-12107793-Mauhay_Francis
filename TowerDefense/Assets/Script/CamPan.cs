using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPan : MonoBehaviour
{
    [SerializeField] float CamSpeed;

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * CamSpeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * CamSpeed);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * CamSpeed);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * CamSpeed);
        }
    }
}
