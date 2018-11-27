using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    
    public Button btnPlay;
    public Button btnQuit;

    // Use this for initialization
    void Start () {

        btnPlay.onClick.AddListener(StartGame);
        btnQuit.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
    

    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    
}
