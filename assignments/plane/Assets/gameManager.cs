using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static gameManager SharedInstance;

    public TMP_Text spellAmountText;

    public int spellAmount = 5;

    // Start is called before the first frame update
    void Start()
    {
        SharedInstance = this;
        UpdateSpellAmount(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSpellAmount(int amount)
    {
        spellAmount = spellAmount + amount;
        spellAmountText.text = spellAmount.ToString();
    }
}
