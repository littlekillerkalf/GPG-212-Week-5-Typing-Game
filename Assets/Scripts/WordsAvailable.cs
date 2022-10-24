using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordsAvailable : MonoBehaviour
{
    public List<int> wordID;
    int itemCount = 0;

    private void Start() {
        GameObject.Find("Database").GetComponent<LoadExcel>().LoadItemData();

        foreach(Item item in GetComponent<LoadExcel>().itemDatabase)
        {
            itemCount++;
        }
        int rand = UnityEngine.Random.Range(0, itemCount);

        wordID.Add(GameObject.Find("Database").GetComponent<LoadExcel>().itemDatabase[rand].id);
        GetComponent<LoadExcel>().itemDatabase.Remove(GetComponent<LoadExcel>().itemDatabase[rand]);
    }

    public void AddNewItem()
    {
        foreach(Item item in GetComponent<LoadExcel>().itemDatabase)
        {
            itemCount++;
        }
        int rand = UnityEngine.Random.Range(0, itemCount);
        
        wordID.Add(GameObject.Find("Database").GetComponent<LoadExcel>().itemDatabase[rand].id);
        GetComponent<LoadExcel>().itemDatabase.Remove(GetComponent<LoadExcel>().itemDatabase[rand]);
    }
}
