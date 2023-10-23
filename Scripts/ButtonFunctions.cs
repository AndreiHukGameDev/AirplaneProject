using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void ExitApp()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Games");

    }

}
