using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void OnDestroy() {
        SceneManager.LoadScene("GameScene");
    }
}
