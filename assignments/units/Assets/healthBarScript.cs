using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class healthBarScript : MonoBehaviour
{
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = UIManagerScript.UISharedInstance.maxHealth;
        healthBar.value = UIManagerScript.UISharedInstance.maxHealth;
    }

    private void OnEnable()
    {
        UIManagerScript.UpdateHealth += SetHealth;
    }

    private void OnDisable()
    {
        UIManagerScript.UpdateHealth -= SetHealth;
    }

    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}