using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript UISharedInstance;
    public TMP_Text endText;
    public Button resetButton;
    public float currentHealth = 99f;
    public float maxHealth = 100f;
    public healthBarScript healthBar;
    public float currentGold = 0f;
    public float maxGold = 50f;
    public goldBarScript goldBar;
    public float currentQuota = 0f;
    public float maxQuota = 300f;
    public quotaBarScript quotaBar;
    public playerScript player;
    public static event Action<float> UpdateHealth;
    public static event Action<float> UpdateGold;
    public static event Action<float> UpdateQuota;
    public static event Action killAnimation;

    void Awake()
    {
        UISharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 99f;
        healthBar.SetHealth(currentHealth);
        currentGold = 0f;
        goldBar.SetGold(currentGold);
        currentQuota = 0f;
        quotaBar.SetQuota(currentQuota);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            killAnimation?.Invoke();
            player.play = false;
            endText.text = "Game Over!";
            resetButton.gameObject.SetActive(true);
        }

        if (currentQuota >= 300)
        {
            player.play = false;
            endText.text = "You Win!";
            resetButton.gameObject.SetActive(true);
        }
        
    }

     public void hurtPlayer(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            UpdateHealth?.Invoke(currentHealth);
        }
    }

    public void healPlayer(float heal)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += heal;
            UpdateHealth?.Invoke(currentHealth);
        }
    }

    public void increaseGold(float increase)
    {
        if (currentGold < maxGold)
        {
            currentGold += increase;
            UpdateGold?.Invoke(currentGold);
        }
    }

    public void decreaseGold(float decrease)
    {
        if (currentGold > 0)
        {
            currentGold -= decrease;
            UpdateGold?.Invoke(currentGold);
        }
    }
    public void updateQuota(float amount)
    {
        if (currentQuota < maxQuota)
        {
            currentQuota += amount;
            UpdateQuota?.Invoke(currentQuota);
        }
    }
}
