using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Witch")) {
            gameManager.SharedInstance.UpdateSpellAmount(1);
            Destroy(gameObject);
        }
    }
}
