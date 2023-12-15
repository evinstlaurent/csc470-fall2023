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
    public AudioSource source;
    public static event Action<string> ShowInputPrompt;
    public static event Action<string> ItemStolen;
    public bool musicPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        if (furnitureName != "Record Player") {
            source.Stop();
            item = false;
            GameManager.SharedInstance.furnitureList.Add(this); 
        } else {
            source.Play();
            item = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (furnitureName == "Record Player")
        {
            if (musicPlaying)
            {
                if (!source.isPlaying)
                {
                    source.Play();
                }
            }
        }
    }

    void checkForItem() {
        if (item) {
            item = false;
            ItemStolen?.Invoke(itemName);
        }
    }

    public void checkForSearchInput() {
        ShowInputPrompt?.Invoke(furnitureName);
        if (Input.GetKeyDown("space")) {
            if (furnitureName == "Record Player") {
                if (item) {
                    source.Pause();
                    item = false;
                    musicPlaying = false;
                    return;
                } else {
                    source.Play();
                    item = true;
                    musicPlaying = true;
                    return;
                }
            }
            source.Play();
            checkForItem();
        }
    }
}
