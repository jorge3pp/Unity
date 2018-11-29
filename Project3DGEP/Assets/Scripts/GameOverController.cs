using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {


    public Button btnPlayAgain;
    public Button btnQuit;

    public Canvas gameOver;

    // Use this for initialization
    void Start()
    {
        btnPlayAgain.onClick.AddListener(StartGame);
        btnQuit.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }


    private void StartGame()
    {
        gameOver.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
