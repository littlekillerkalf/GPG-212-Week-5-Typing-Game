using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordsAvailable : MonoBehaviour
{
    public List<int> wordID;
    GameObject database;
    GameObject gameManager;

    private void Start() 
    {
        database = GameObject.Find("Database"); 
        database.GetComponent<LoadExcel>().LoadItemData();

        gameManager = GameObject.Find("GameManager");
        
        int itemCount = 0;
        
        foreach(Item item in GetComponent<LoadExcel>().itemDatabase)
        {
            itemCount++;
        }
        
        int rand = UnityEngine.Random.Range(0, itemCount);

        wordID.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].id);
        Debug.Log(wordID.Count());
        StartCoroutine(gameManager.GetComponent<WaveHandler>().NewWave());
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
            
            if(!wordID.Contains(database.GetComponent<LoadExcel>().itemDatabase[rand].id)&& wordID.Count() < itemCount)
            {
                wordID.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].id);
                gameManager.GetComponent<WaveHandler>().NewWave();
            }
            else if (wordID.Contains(database.GetComponent<LoadExcel>().itemDatabase[rand].id)&& wordID.Count() < itemCount)
            {
                while(wordID.Contains(database.GetComponent<LoadExcel>().itemDatabase[rand].id) )
                {
                    rand = UnityEngine.Random.Range(0, itemCount);
                }
                wordID.Add(database.GetComponent<LoadExcel>().itemDatabase[rand].id);
            }
            else
            {
                return;
            }

            StartCoroutine(gameManager.GetComponent<WaveHandler>().NewWave());
        }
    }
}
