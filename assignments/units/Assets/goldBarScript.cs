using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class goldBarScript : MonoBehaviour
{
    public Slider goldBar;

    // Start is called before the first frame update
    void Start()
    {
        goldBar = GetComponent<Slider>();
        goldBar.maxValue = UIManagerScript.UISharedInstance.maxGold;
        goldBar.value = UIManagerScript.UISharedInstance.maxGold;
    }

    private void OnEnable()
    {
        UIManagerScript.UpdateGold += SetGold;
    }

    private void OnDisable()
    {
        UIManagerScript.UpdateGold -= SetGold;
    }

    public void SetGold(float goldAmt)
    {
        goldBar.value = goldAmt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}