using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Has a Play, Load Level, and Exit button
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Play button prefab
    /// </summary>
    public Button btnPlay;
    /// <summary>
    /// Load Level button prefab
    /// </summary>
    public Button btnLoadLevel;
    /// <summary>
    /// Exit button prefab
    /// </summary>
    public Button btnExit;

    /// <summary>
    /// Add event listeners to buttons
    /// </summary>
    void Start()
    {
        btnPlay.onClick.AddListener(ButtonPlay_Clicked);
        btnLoadLevel.onClick.AddListener(ButtonLoadLevel_Clicked);
        btnExit.onClick.AddListener(ButtonExit_Clicked);
    }

    /// <summary>
    /// Load Level01 on click
    /// </summary>
    void ButtonPlay_Clicked()
    {
        SceneManager.LoadScene("Level01");
    }

    /// <summary>
    /// Load the Level Menu on click
    /// </summary>
    void ButtonLoadLevel_Clicked()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    /// <summary>
    /// Terminate application on click
    /// </summary>
    void ButtonExit_Clicked()
    {
        Application.Quit();
    }
}
