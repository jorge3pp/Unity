using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    private GameInstance instance;
    public Text txtUsername;

    public Button btnPlay;
    public Button btnDelete;
    public Button btnQuit;

    private string username;

    // Use this for initialization
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (gameController != null)
        {
            instance = gameController.GetComponent<GameInstance>();

            txtUsername.text = instance.UserProfile.Username;
            btnPlay.onClick.AddListener(StartGame);
            btnDelete.onClick.AddListener(DeleteProfileAndRestart);
            btnQuit.onClick.AddListener(QuitGame);
        }

    }

    private void QuitGame()
    {
        instance.Quit();
    }

    private void DeleteProfileAndRestart()
    {
        instance.DeleteProfile();
        instance.LoadScene("profile");
    }

    private void StartGame()
    {
        instance.LoadScene("game");
    }
}
