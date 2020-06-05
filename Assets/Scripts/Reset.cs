using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Reset : MonoBehaviour
{
    private int currentScene;

    void Start() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void ResetGame() {
        Debug.Log("Reseting Game");
        SceneManager.LoadScene(currentScene);
    }
}
