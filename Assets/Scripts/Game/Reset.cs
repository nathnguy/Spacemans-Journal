using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Reset : MonoBehaviour
{
    private int currentScene;

    void Awake() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void ResetGame() {
        SceneManager.LoadScene(currentScene);
    }
}
