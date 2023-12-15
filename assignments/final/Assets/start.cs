using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class start : MonoBehaviour
{
    public Button rulesButton;
    public Button backButton;
    public Button startButton;
    public TMP_Text titleText;
    public TMP_Text rulesTitle;
    public TMP_Text rulesText;

    // Start is called before the first frame update
    void Start()
    {
        rulesButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        titleText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        rulesTitle.gameObject.SetActive(false);
        rulesText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void rules()
    {
        rulesButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
        rulesTitle.gameObject.SetActive(true);
        rulesText.gameObject.SetActive(true);
    }

    public void back()
    {
        rulesButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        titleText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        rulesTitle.gameObject.SetActive(false);
        rulesText.gameObject.SetActive(false);
    }
}
