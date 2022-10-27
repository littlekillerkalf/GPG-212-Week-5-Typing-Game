using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;

public class DestroyEnemy : MonoBehaviour
{
    Animator anim;
    WordsAvailable wordsAvailable;
    [SerializeField]
    TMP_Text wordText;

    private void Start()
    {
        anim = GetComponent<Animator>();
        wordsAvailable = GameObject.Find("Database").GetComponent<WordsAvailable>();
        wordText.text = "<color=yellow>"+GameObject.Find("GameManager").GetComponent<InputController>().activeString+"</color>";
        wordsAvailable.activeWord = null;
        wordsAvailable.hasActiveWord = false;
        wordsAvailable.enemiesKilledThisWave++;
        GameObject.Find("GameManager").GetComponent<InputController>().currentIndex = 0;
        GameObject.Find("GameManager").GetComponent<InputController>().currentInputs = string.Empty;
    }
    private void Update()
    {
        if(!anim.IsInTransition(0))
        {
            return;
        }
        else
        {
            Destroy(anim.gameObject);
        }
    }
}
