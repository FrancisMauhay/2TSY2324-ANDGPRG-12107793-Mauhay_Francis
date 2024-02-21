using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
}
