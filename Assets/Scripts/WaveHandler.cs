using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    private GameObject database;
    public GameObject cube;
    [SerializeField]
    public Transform spawnLocation;

    private void Start() {
        database = GameObject.Find("Database");
    }


    public IEnumerator NewWave()
    {    
        foreach(int itemId in database.GetComponent<WordsAvailable>().wordID.ToArray())
        {
            foreach(Item item in database.GetComponent<LoadExcel>().itemDatabase)
            {
                if(item.id == itemId)
                {
                    yield return new WaitForSeconds(1f);
                    spawnWord(item.word, item.definition, item.lives, item.startingLetter);
                }
            }
        }
    }

    private void spawnWord(string word, string definition, int health, string startingLetter)
    {
        GameObject enemy = Instantiate(cube, spawnLocation);
        stats enemyStats = enemy.GetComponent<stats>();
        enemyStats.word = word;
        enemyStats.definition = definition;
        enemyStats.health = health;
        enemyStats.startingLetter = startingLetter;
    }
}
