using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    public List<string> stealList = new List<string>();
    public TMP_Text listText;
    public TMP_Text timerText;
    public TMP_Text promptText;
    public TMP_Text loseText;
    public Button mainButton;
    public Button resetButton;
    public Image loseBackground;
    public Slider noiseBar;
    public Slider lightBar;
    public GameObject headlampLight;
    public furnitureScript recordPlayer;
    public playerScript player;
    float currentBattery;
    float maxBattery = 200;
    float minBattery = 0;
    float currentNoise;
    float maxNoise = 200;
    float minNoise = 0;
    public int time;
    public int minNumObj;
    public int maxNumObj;
    int num;
    int randIndex;
    public List<furnitureScript> furnitureList = new List<furnitureScript>();

    void Awake()
    {
        SharedInstance = this;
    }

    void OnEnable()
    {
        playerScript.UpdateNoise += SetNoise;
        furnitureScript.ShowInputPrompt += inputPrompt;
        playerScript.ClearInputPrompt += clearPromptText;
        furnitureScript.ItemStolen += removeStolenObject;
    }
    void OnDisable()
    {
        playerScript.UpdateNoise -= SetNoise;
        furnitureScript.ShowInputPrompt -= inputPrompt;
        playerScript.ClearInputPrompt -= clearPromptText;
        furnitureScript.ItemStolen -= removeStolenObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        assignItems();
        for (int i = 0; i < stealList.Count; i++) {
            listText.text +=stealList[i];
            if (i != stealList.Count-1) {
                listText.text += " | ";
            }
        }
        
        currentNoise = minNoise;
        SetNoise(1);
        currentBattery = maxBattery;
        timerText.text = "Time: "+time;
        StartCoroutine(timerTick());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNoise >= maxNoise) {
            player.play = false;
            loseBackground.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
            mainButton.gameObject.SetActive(true);
            loseText.gameObject.SetActive(true);
        }
        if (time < 0) {
            player.play = false;
            loseBackground.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
            mainButton.gameObject.SetActive(true);
            loseText.gameObject.SetActive(true);
        }
        if (headlampLight.gameObject.activeSelf == true)
        {
            if (currentBattery >= minBattery)
            {
                currentBattery -= 0.05f;
                lightBar.value = currentBattery;
            } else 
            {
                headlampLight.gameObject.SetActive(false);
            }
        } else if (headlampLight.gameObject.activeSelf == false)
        {
            if (currentBattery < maxBattery) {
                currentBattery += 0.1f;
                lightBar.value = currentBattery;
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (headlampLight.gameObject.activeSelf == false)
            {
                headlampLight.gameObject.SetActive(true);
            } else if (headlampLight.gameObject.activeSelf == true)
            {
                headlampLight.gameObject.SetActive(false);
            }
        }
    }

    public void removeStolenObject(string stolen)
    {
        stealList.Remove(stolen);
        if (stealList.Count == 0) {
            listText.text = "All items found. Find your way out.";
        } else {
            listText.text = "";
            for (int i = 0; i < stealList.Count; i++) {
                listText.text +=stealList[i];
                if (i != stealList.Count-1) {
                    listText.text += " | ";
                }
            }
        }
    }

    public void SetNoise(float noise)
    {
        if (noise > 0)
        {
            if (currentNoise < maxNoise)
            {
                if (recordPlayer.item) {
                    noise = noise*2f;
                }
                currentNoise += noise;
                noiseBar.value = currentNoise;
            }
        }
        if (noise < 0)
        {
            if (currentNoise > minNoise)
            {
                currentNoise += noise;
                noiseBar.value = currentNoise;
            }
        }
    }

    public void inputPrompt(string furnitureName)
    {
        promptText.text = "Press Space to search the\n"+furnitureName;
    }

    public void clearPromptText()
    {
        promptText.text = "";
    }

    IEnumerator timerTick()
    {
        while(time >= 0) {
            timerText.text = "Time: "+time;
            time -= 1;
            yield return new WaitForSeconds(1);
        }
    }

    void assignItems()
    {
        num = Random.Range(minNumObj,maxNumObj);
        while(num > 0) {
            randIndex = Random.Range(0, furnitureList.Count-1);
            if (!furnitureList[randIndex].item) {
                furnitureList[randIndex].item = true;
                stealList.Add(furnitureList[randIndex].itemName);
                num -= 1;
            }
        }
    }

    public void resetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void goMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-SceneManager.GetActiveScene().buildIndex);
    }
}
