using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // forward movement of player restricted with player bounds for the W key
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.forward * 20 * Time.deltaTime;

            if (transform.position.z >= 205 || transform.position.z <= -215 || transform.position.x >= 58 || transform.position.x <= -58)
            {
                transform.position = transform.position - transform.forward * 20 * Time.deltaTime;
            }
        }

        // backward movement of player restricted with player bounds for the S key
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.forward * 20 * Time.deltaTime;

            if (transform.position.z >= 205 || transform.position.z <= -215 || transform.position.x >= 58 || transform.position.x <= -58)
            {
                transform.position = transform.position + transform.forward * 20 * Time.deltaTime;
            }
        }

        // rightward movement of player restricted with player bounds for the D key
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * 20 * Time.deltaTime;

            if (transform.position.z >= 205 || transform.position.z <= -215 || transform.position.x >= 58 || transform.position.x <= -58)
            {
                transform.position = transform.position - transform.right * 20 * Time.deltaTime;
            }
        }

        // leftward movement of player restricted with player bounds for the A key
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - transform.right * 20 * Time.deltaTime;

            if (transform.position.z >= 205 || transform.position.z <= -215 || transform.position.x >= 58 || transform.position.x <= -58)
            {
                transform.position = transform.position + transform.right * 20 * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(0, 2, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(0, -2, 0);
        }

    }
}
