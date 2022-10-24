using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string word;
    public string definition;
    public int lives;
    public string startingLetter;


    // Start is called before the first frame update
    public Item(Item d)
    {
        id = d.id;
        word = d.word;
        definition = d.definition;
        lives = d.lives;
        startingLetter = d.startingLetter;
    }
}
