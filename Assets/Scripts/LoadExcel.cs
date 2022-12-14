using System.Xml;
using System.IO.Enumeration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadExcel : MonoBehaviour
{
    public Item blankItem;
    public List<Item> itemDatabase = new List<Item>();

    public void LoadItemData()
    {
        // Clear The Database
        itemDatabase.Clear();

        // Read The CSV Files
        List<Dictionary<string, object>> data = CSVReader.Read("words3test");

        

        for(var i = 0; i < data.Count; i++)
        {
            int id = int.Parse(data[i]["ID"].ToString(), System.Globalization.NumberStyles.Integer);
            string word = data[i]["Word"].ToString();
            string definition = data[i]["Definition"].ToString();
            int lives = int.Parse(data[i]["Lives"].ToString(), System.Globalization.NumberStyles.Integer);
            string startingLetter = data[i]["Starting Letter"].ToString();
        
            AddItem(id, word, definition, lives, startingLetter);
        }
    }

    void AddItem(int id, string word, string definition, int lives, string startingLetter)
    {
        Item tempItem = new Item(blankItem);
        tempItem.id = id;
        Debug.Log(id);
        tempItem.definition = definition;
        Debug.Log(definition);
        tempItem.word = word;
        Debug.Log(word);
        tempItem.lives = lives;
        Debug.Log(lives);
        tempItem.startingLetter = startingLetter;
        Debug.Log(startingLetter);
        itemDatabase.Add(tempItem);
    }

}
