using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    TMP_Text wordText;
    GameObject database;
    WordsAvailable wordsAvailable;

    private void Start() {
        wordText.text = word;
        database = GameObject.Find("Database");
        wordsAvailable = GameObject.Find("Database").GetComponent<WordsAvailable>();
    }

    private void Update() {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        wordsAvailable.activeWord = null;
        wordsAvailable.hasActiveWord = false;
        GameObject.Find("GameManager").GetComponent<InputController>().currentIndex = 0;
    }

}
