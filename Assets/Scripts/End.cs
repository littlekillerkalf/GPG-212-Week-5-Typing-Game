using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject endScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.tag == "Enemy")
        {
            endScreen.SetActive(true);
        }
    }
}
