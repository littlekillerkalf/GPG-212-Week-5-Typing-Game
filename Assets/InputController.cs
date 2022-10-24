using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private WordsAvailable wordsAvailable;
    public int currentIndex = 0;

    private void Start() {
        wordsAvailable = GameObject.Find("Database").GetComponent<WordsAvailable>();
    }
    // Update is called once per frame
    void Update()
    {
        foreach(char letter in Input.inputString.ToLower())
        {
            if(wordsAvailable.hasActiveWord == true)
            {
                Debug.Log(letter);
                if(letter == wordsAvailable.activeWord.GetComponent<stats>().word.ToLower()[currentIndex])
                {
                    currentIndex++;
                    wordsAvailable.activeWord.GetComponent<stats>().health --;
                }
            }
            else
            {
                foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Word"))
                {
                    if(enemy.GetComponent<stats>().word.ToLower().StartsWith(letter))
                    {
                        wordsAvailable.hasActiveWord = true;
                        wordsAvailable.activeWord = enemy;
                        currentIndex++;
                        enemy.GetComponent<stats>().health --;
                        break;
                    }
                }
            }
        }
    }
}
