using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Launch screen that shows game title
/// </summary>
public class TitleScreen : MonoBehaviour
{
    /// <summary>
    /// Check for left mouse down then load Main Menu
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("MainMenu");
    }
}
