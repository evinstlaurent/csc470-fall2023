using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    public playerScript PlayerScript;

    public List<string> stealList = new List<string>();

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        stealList.Add("Necklace");
        stealList.Add("Watch");
        stealList.Add("Diamond");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeStolenObject(string stolen) {
        stealList.Remove(stolen);
        Debug.Log(stealList.Count);
    }
}
