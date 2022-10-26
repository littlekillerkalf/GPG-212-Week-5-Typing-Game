using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class stats : MonoBehaviour
{
    [SerializeField]
    public int health = 0;
    [SerializeField]
    public string word;
    [SerializeField]
    public string definition;
    [SerializeField]
    public string startingLetter;
    [SerializeField]
    public TMP_Text wordText;
    GameObject database;
    WordsAvailable wordsAvailable;

    private GameObject gameManager;

    private void Start() {
        if(wordText != null) wordText.text = word;
        database = GameObject.Find("Database");
        wordsAvailable = GameObject.Find("Database").GetComponent<WordsAvailable>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Update() {
        if(health <= 0)
        {
            Destroy(gameObject);
            gameManager.GetComponent<WaveHandler>().score ++;
        }
    }

    private void OnDestroy() {
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            wordsAvailable.activeWord = null;
            wordsAvailable.hasActiveWord = false;
            wordsAvailable.enemiesKilledThisWave++;
            GameObject.Find("GameManager").GetComponent<InputController>().currentIndex = 0;
            GameObject.Find("GameManager").GetComponent<InputController>().currentInputs = string.Empty;
        }
        
    }

}
