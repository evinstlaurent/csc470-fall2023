using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class furnitureScript : MonoBehaviour
{
    public bool item;
    public string itemName;
    public string furnitureName;
    public static event Action<string> ShowInputPrompt;
    public static event Action<string> ItemStolen;

    // Start is called before the first frame update
    void Start()
    {
        item = false;
        GameManager.SharedInstance.furnitureList.Add(this); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void checkForItem() {
        if (item) {
            Debug.Log(itemName);
            item = false;
            ItemStolen?.Invoke(itemName);
        }
    }

    public void checkForSearchInput() {
        ShowInputPrompt?.Invoke(furnitureName);
        if (Input.GetKeyDown("space")) {
            checkForItem();
        }
    }
}
