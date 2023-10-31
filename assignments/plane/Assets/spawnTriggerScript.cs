using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTriggerScript : MonoBehaviour
{
    public GameObject magicBall;
    bool ballPresent = true;
    float respawnTime = 20f;
    float timeLeft = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(magicBall, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (ballPresent != true) {
            if (timeLeft <= 0) {
                Instantiate(magicBall, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            }
            if (timeLeft > 0) {
                timeLeft -= Time.deltaTime;
            }
        }
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Magic Ball")) {
            ballPresent = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Witch")) {
            Debug.Log("hello");
            ballPresent = false;
            timeLeft = respawnTime;
        }
    }
}
