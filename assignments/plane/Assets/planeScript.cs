using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeScript : MonoBehaviour
{
    float forwardSpeed = 10f;
    float xRotationSpeed = 10f;
    float yRotationSpeed = 10f;
    float zRotationSpeed = 10f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        float xRotation = vAxis * xRotationSpeed * Time.deltaTime;
        float yRotation = hAxis * yRotationSpeed * Time.deltaTime;
        float zRotation = hAxis * zRotationSpeed * Time.deltaTime;

        transform.Rotate(xRotation, yRotation, -zRotation, Space.Self);  

        gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * forwardSpeed;
        
    }
}
