using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public SceneFader SceneFader;
    
    public void Retry()
    {
        SceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneFader.FadeTo(menuSceneName);
    }
}
