using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Database").GetComponent<LoadExcel>().LoadItemData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
