using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class WordsAvailable : MonoBehaviour
{
    public List<int> wordID;
    GameObject database;
    GameObject gameManager;

    public int wave = 0;
    public int enemiesKilledThisWave = 0;

    public bool hasActiveWord = false;
    public GameObject activeWord;

    public delegate void LoadNewWaveEvent();
    public static event LoadNewWaveEvent loadNewWaveEvent;

    private void Start() 
    {
        database = GameObject.Find("Database"); 
        database.GetComponent<LoadExcel>().LoadItemData();

        gameManager = GameObject.Find("GameManager");

        wave = 0;
    }

    private void OnEnable() {
        loadNewWaveEvent += newWaveEvent;
    }

    private void OnDisable() {
        loadNewWaveEvent -= newWaveEvent;
    }

    private void Update() {
        if(enemiesKilledThisWave == wave)
        {
            wave ++;
            enemiesKilledThisWave = 0;
            loadNewWaveEvent?.Invoke();
        }
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
            if(!IsIDUsed(rand) && wordID.Count() < itemCount)
            {
                wordID.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].id);
                StartCoroutine(gameManager.GetComponent<WaveHandler>().NewWave());
                return;
            }

            // If the Word ID is in the list, loop through until it is not
            else if (IsIDUsed(rand) && wordID.Count() < itemCount)
            {
                while((IsIDUsed(rand)))
                {
                    rand = UnityEngine.Random.Range(0, itemCount);
                }
                wordID.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].id);
                StartCoroutine(gameManager.GetComponent<WaveHandler>().NewWave());
                return;
            }

            else
            {
                return;
            }
        }
    }   

    void newWaveEvent()
    {
        StartCoroutine(LoadNewWave());
    }

    IEnumerator LoadNewWave()
    {
        yield return new WaitForSeconds(2);
        AddNewItem();
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
}
