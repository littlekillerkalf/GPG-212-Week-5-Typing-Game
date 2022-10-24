using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordsAvailable : MonoBehaviour
{
    public List<int> wordID;
    public List<string> currentLetters;
    GameObject database;
    GameObject gameManager;
    string prevStartingLetter;

    public bool hasActiveWord = false;
    public GameObject activeWord;

    private void Start() 
    {
        database = GameObject.Find("Database"); 
        database.GetComponent<LoadExcel>().LoadItemData();

        gameManager = GameObject.Find("GameManager");
    }

    /// <summary>
    /// Adds A new item To The wordID list, determining what ID's can be added to the game.
    /// </summary>
    public void AddNewItem()
    {
        if(database.GetComponent<LoadExcel>().itemDatabase.Count != 0)
        {
            int itemCount = 0;
            foreach(Item item in GetComponent<LoadExcel>().itemDatabase)
            {
                itemCount++;
            }
            
            int rand = UnityEngine.Random.Range(0, itemCount);
            
            //checks to ensure the Id isnt already in the list WordID
            if(!IsIDUsed(rand) && wordID.Count() < itemCount && !IsStartingLetterInGame(rand))
            {
                wordID.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].id);
                currentLetters.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].startingLetter);
                // gameManager.GetComponent<WaveHandler>().NewWave();
                StartCoroutine(gameManager.GetComponent<WaveHandler>().NewWave());
                return;
            }

            // If the Word ID is in the list, loop through until it is not
            else if (IsIDUsed(rand) && wordID.Count() < itemCount && !IsStartingLetterInGame(rand))
            {
                while((IsIDUsed(rand) && IsStartingLetterInGame(rand)) || (IsIDUsed(rand)&& !IsStartingLetterInGame(rand)) || (!IsIDUsed(rand) && IsStartingLetterInGame(rand)))
                {
                    rand = UnityEngine.Random.Range(0, itemCount);
                }
                wordID.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].id);
                currentLetters.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].startingLetter);
                // gameManager.GetComponent<WaveHandler>().NewWave();
                StartCoroutine(gameManager.GetComponent<WaveHandler>().NewWave());
                return;
            }
            
            else if (IsStartingLetterInGame(rand) && !IsIDUsed(rand) && wordID.Count() < itemCount)
            {
                while((IsIDUsed(rand) && IsStartingLetterInGame(rand)) || (IsIDUsed(rand)&& !IsStartingLetterInGame(rand)) || (!IsIDUsed(rand) && IsStartingLetterInGame(rand)))
                {
                    rand = UnityEngine.Random.Range(0, itemCount);
                }
                wordID.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].id);
                currentLetters.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].startingLetter);
                // gameManager.GetComponent<WaveHandler>().NewWave();
                StartCoroutine(gameManager.GetComponent<WaveHandler>().NewWave());
                return;
            }

            else if (IsStartingLetterInGame(rand) && IsIDUsed(rand) && wordID.Count() < itemCount)
            {
                while((IsIDUsed(rand) && IsStartingLetterInGame(rand)) || (IsIDUsed(rand)&& !IsStartingLetterInGame(rand)) || (!IsIDUsed(rand) && IsStartingLetterInGame(rand)))
                {
                    rand = UnityEngine.Random.Range(0, itemCount);
                }
                wordID.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].id);
                currentLetters.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].startingLetter);
                // gameManager.GetComponent<WaveHandler>().NewWave();
                StartCoroutine(gameManager.GetComponent<WaveHandler>().NewWave());
                return;
            }   

            else
            {
                
                return;
            }
        }
    }   


    bool IsIDUsed(int random)
    {
        if(wordID.Contains(database.GetComponent<LoadExcel>().itemDatabase[random].id))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsStartingLetterInGame(int random)
    {
        if(currentLetters.Contains(database.GetComponent<LoadExcel>().itemDatabase[random].startingLetter))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
