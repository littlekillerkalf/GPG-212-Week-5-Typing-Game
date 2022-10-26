using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveHandler : MonoBehaviour
{
    private GameObject database;
    public GameObject cube;
    [SerializeField]
    public Transform spawnLocation;

    public TextMeshProUGUI waveText;
    private int waveCount;

    public TextMeshProUGUI scoreText;
    public int score = 0;
    private void Start() {
        database = GameObject.Find("Database");
    }

    private void Update()
    {
        waveText.text = "Wave:" + waveCount.ToString();
        scoreText.text = "Score:" + score.ToString();
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
        waveCount++;
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
