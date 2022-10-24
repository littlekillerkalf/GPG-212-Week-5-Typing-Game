using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class stats : MonoBehaviour
{
    [SerializeField]
    public int health = 0;
    [SerializeField]
    public string word;
    [SerializeField]
    public string definition;
    [SerializeField]
    TMP_Text wordText;

    private void Start() {
        wordText.text = word;
    }

}
