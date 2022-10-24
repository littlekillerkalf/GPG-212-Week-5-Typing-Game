using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    private GameObject database;
    public GameObject cube;


    private void Start() {
        database = GameObject.Find("Database");
    }

    public IEnumerator NewWave()
    {    
        // Debug.Log("Entered New Wave");
        foreach(int itemId in database.GetComponent<WordsAvailable>().wordID.ToArray())
        {
            // Debug.Log(itemId);
            foreach(Item item in database.GetComponent<LoadExcel>().itemDatabase)
            {
                // UnityEngine.Debug.Log(item.id);
                // UnityEngine.Debug.Log(itemId);
                if(item.id == itemId)
                {
                    // UnityEngine.Debug.Log("test");
                    spawnWord(item.word, item.definition, item.lives);
                    yield return new WaitForSeconds(3);
                }
            }
        }
    }

    private void spawnWord(string word, string definition, int health)
    {
        GameObject enemy = Instantiate(cube);
        stats enemyStats = enemy.GetComponent<stats>();
        enemyStats.word = word;
        enemyStats.definition = definition;
        enemyStats.health = health;

    }
}
