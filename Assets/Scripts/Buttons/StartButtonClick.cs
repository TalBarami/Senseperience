using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : ButtonClickScript
{
    public override void Execute()
    {
        Debug.Log("Starting Game Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit function - Quitting");
        Application.Quit();
    }
}
