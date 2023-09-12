using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeBurn : MonoBehaviour
{
    public GameObject deadTreePrefab;
    public GameObject firePrefab;

    public bool burned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.F)))
        {
            arson();
        }     
    }

    // the arson fuction carries out the generating of the fire and dead tree as well as destroying the tree object
    void arson()
    {
        // burner value allows for staggered burn with random number assignment to each tree with key press
            int burner = Random.Range(1,10);

            if (burner == 1)
            {
                if (burned is false)
                {
                    burned = true;
                    Vector3 treePosition = gameObject.transform.position;
                    GameObject deadTree = Instantiate(deadTreePrefab, treePosition, Quaternion.identity);
                    deadTree.transform.Rotate(0, Random.Range(0,359), 0);
                    GameObject fire = Instantiate(firePrefab, treePosition, Quaternion.identity);
                    fire.transform.Rotate(0, Random.Range(0,359), 0);
                    Destroy(gameObject, 5);
                    Destroy(fire, 5);
                }
            }
    }
}
