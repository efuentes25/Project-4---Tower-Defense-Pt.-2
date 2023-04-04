using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    
    public string nextLevel = "Level02";
    public int leveToUnlock = 2;

    public SceneFader SceneFader;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", leveToUnlock);
        SceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        SceneFader.FadeTo(menuSceneName);
    }
}
