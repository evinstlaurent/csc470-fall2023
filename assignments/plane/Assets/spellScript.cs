using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("TV")) {
            other.gameObject.transform.position = new Vector3 (438,1,424);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Couch")) {
            other.gameObject.transform.position = new Vector3 (442,0,429);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Chair 1")) {
            other.gameObject.transform.position = new Vector3 (437,0,431);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Chair 2")) {
            other.gameObject.transform.position = new Vector3 (441,0,431);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Table")) {
            other.gameObject.transform.position = new Vector3 (440,0,428);
            other.gameObject.transform.Rotate(0,90,0);
            Destroy(this.gameObject);
        }
    }
}
