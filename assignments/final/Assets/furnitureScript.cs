using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class furnitureScript : MonoBehaviour
{
    public bool item;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkForItem() {
        if (item) {
            Debug.Log(itemName);
            item = false;
            GameManager.SharedInstance.removeStolenObject(itemName);
        }
    }

    public void checkForSearchInput() {
        if (Input.GetKeyDown("space")) {
            checkForItem();
        }
    }
}
