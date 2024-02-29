using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPan : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back);
        }
    }
}
