using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class quotaBarScript : MonoBehaviour
{
    public Slider quotaBar;

    // Start is called before the first frame update
    void Start()
    {
        quotaBar = GetComponent<Slider>();
        quotaBar.maxValue = UIManagerScript.UISharedInstance.maxQuota;
        quotaBar.value = UIManagerScript.UISharedInstance.maxQuota;
    }

    private void OnEnable()
    {
        UIManagerScript.UpdateQuota += SetQuota;
    }

    private void OnDisable()
    {
        UIManagerScript.UpdateQuota -= SetQuota;
    }

    public void SetQuota(float quotaAmt)
    {
        quotaBar.value = quotaAmt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}