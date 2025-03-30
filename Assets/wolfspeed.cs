using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfspeed : MonoBehaviour
{
    public float wolfSpeed = 1.0f; // Initial speed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.forward
        //transform.TransformDirection(Vector3.forward)
        //transform.position = transform.position + Camera.main.transform.forward * wolfSpeed * Time.deltaTime;
        transform.position += transform.TransformDirection(Vector3.forward) * wolfSpeed * Time.deltaTime;
    }
}
