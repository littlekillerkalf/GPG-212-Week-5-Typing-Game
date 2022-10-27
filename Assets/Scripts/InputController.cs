using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InputController : MonoBehaviour
{
    private WordsAvailable wordsAvailable;
    public int currentIndex = 0;
    public string currentInputs;
    public string activeString;

    private void Start() {
        wordsAvailable = GameObject.Find("Database").GetComponent<WordsAvailable>();
        currentInputs = string.Empty;
    }
    // Update is called once per frame
    void Update()
    {
        foreach(char letter in Input.inputString.ToLower())
        {
            if(wordsAvailable.hasActiveWord == true)
            {
                activeString = wordsAvailable.activeWord.GetComponent<stats>().word;
                Debug.Log(letter);
                if(letter == wordsAvailable.activeWord.GetComponent<stats>().word.ToLower()[currentIndex] && SceneManager.GetActiveScene().name == "GameScene" && GameObject.Find("EndScreen") == null)
                {
                    currentInputs += letter.ToString();
                    currentIndex++;
                    wordsAvailable.activeWord.GetComponent<stats>().health --;
                    wordsAvailable.activeWord.GetComponent<stats>().wordText.text = "";
                    string temp = string.Empty;
                    for(int i = 0; i < wordsAvailable.activeWord.GetComponent<stats>().word.Length-currentIndex; i++)
                    {
                        temp += "_";
                    }
                    wordsAvailable.activeWord.GetComponent<stats>().wordText.text = "<color=yellow>" + wordsAvailable.activeWord.GetComponent<stats>().startingLetter+currentInputs + "</color>" + temp;
                    if(wordsAvailable.activeWord.GetComponent<stats>().health > 1 && wordsAvailable.activeWord.GetComponent<Animator>() != null)
                    {
                        StartCoroutine(AnimationControl());
                    }
                    else
                    {
                        break;
                    }
                }
                else if(letter == wordsAvailable.activeWord.GetComponent<stats>().word.ToLower()[currentIndex])
                {
                    wordsAvailable.activeWord.transform.GetChild(currentIndex).GetComponent<TMP_Text>().text = "<color=yellow>"+letter.ToString().ToUpper() + "</color>";
                    currentIndex++;
                    wordsAvailable.activeWord.GetComponent<stats>().health --;
                    
                }
            }
            else
            {
                foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Word"))
                {
                    if(enemy.GetComponent<stats>().word.ToLower().StartsWith(letter) && SceneManager.GetActiveScene().name == "GameScene" && GameObject.Find("EndScreen") == null)
                    {
                        wordsAvailable.hasActiveWord = true;
                        wordsAvailable.activeWord = enemy;
                        currentIndex++;
                        enemy.GetComponent<stats>().health --;
                        enemy.GetComponent<stats>().wordText.text = "";
                        string temp = string.Empty;
                        for(int i = 0; i < enemy.GetComponent<stats>().word.Length-currentIndex; i++)
                        {
                            temp += "_";
                        }
                        enemy.GetComponent<stats>().wordText.text = "<color=yellow>"+enemy.GetComponent<stats>().startingLetter+"</color>" + temp;
                        if(wordsAvailable.activeWord.GetComponent<Animator>() != null) StartCoroutine(AnimationControl());
                        break;
                    }
                    else if(enemy.GetComponent<stats>().word.ToLower().StartsWith(letter))
                    {
                        wordsAvailable.hasActiveWord = true;
                        wordsAvailable.activeWord = enemy;
                        currentIndex++;
                        enemy.GetComponent<stats>().health --;
                        wordsAvailable.activeWord.GetComponentInChildren<TMP_Text>().text = "<color=yellow>"+enemy.GetComponent<stats>().startingLetter.ToUpper()+"</color>";
                    }
                }
            }
        }
    }

    IEnumerator AnimationControl()
    {
        wordsAvailable.activeWord.GetComponent<Animator>().SetBool("hit", true);
        yield return new WaitForSeconds(0.1f);
        if(wordsAvailable.activeWord.GetComponent<Animator>()!= null)
        {
            wordsAvailable.activeWord.GetComponent<Animator>().SetBool("hit", false);
        }
    }
}
