using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Rigidbody rb;

    public float rotationSpeed;
  
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.x);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(inputDir != Vector3.zero)
        {
            player.forward = Vector3.Slerp(player.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
