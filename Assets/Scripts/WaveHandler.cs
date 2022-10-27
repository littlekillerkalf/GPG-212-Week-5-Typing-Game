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

    public GameObject newWave;

    [SerializeField]
    TMP_Text definitionText;
    [SerializeField]
    TMP_Text wordText;
    bool firstEnemy = true;
    private void Start() {
        database = GameObject.Find("Database");
    }

    private void Update()
    {
        waveText.text = "Wave:" + waveCount.ToString();
        scoreText.text = "WordsCorrect:" + score.ToString();
    }
    public IEnumerator NewWave()
    {    
        if(GameObject.Find("Start")!= null)
        {
            wordText.text = database.GetComponent<WordsAvailable>().newWord;
            definitionText.text = database.GetComponent<WordsAvailable>().newDefinition;
            newWave.SetActive(true);
            waveCount++;
            foreach(int itemId in database.GetComponent<WordsAvailable>().wordID.ToArray())
            {
                foreach(Item item in database.GetComponent<LoadExcel>().itemDatabase)
                {
                    if(item.id == itemId && !firstEnemy)
                    {
                        yield return new WaitForSeconds(1f);
                        spawnWord(item.word, item.definition, item.lives, item.startingLetter);
                        UnityEngine.Debug.Log((item.word));
                        newWave.SetActive(false);
                    }
                    else if(item.id == itemId)
                    {
                        firstEnemy = false;
                        yield return new WaitForSeconds(8f);
                        spawnWord(item.word, item.definition, item.lives, item.startingLetter);
                        UnityEngine.Debug.Log((item.word));
                        newWave.SetActive(false);
                    }
                }
            }
            firstEnemy = true;
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
