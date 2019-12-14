using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Menu for selecting one of 6 scenes
/// Buttons are added programmatically using prefabs
/// Has Back button that returns to Main Menu
/// </summary>
public class LevelMenu : MonoBehaviour
{
    /// <summary>
    /// Back button prefab
    /// </summary>
    public Button btnBackPrefab;
    /// <summary>
    /// Level button prefab
    /// </summary>
    public Button btnLevelPrefab;
    /// <summary>
    /// Collection of sprites from the Images folder
    /// </summary>
    public List<Sprite> sprites;
    /// <summary>
    /// Array of info applied to buttons when creating them
    /// </summary>
    private Levels levelInfo = new Levels();

    /// <summary>
    /// Populate levelInfo
    /// Add prefab buttons to scene
    /// </summary>
    void Start()
    {
        levelInfo.levels = new LevelInfo[6];

        // add levels 1 through 6 to levelInfo
        for (int i = 1; i < 7; i++)
            AddLevel("Level " + i, i);

        AddLevelButtons();
        AddBackButton();
    }

    /// <summary>
    /// Creates and adds a new LevelInfo to Levels
    /// </summary>
    /// <param name="name"></param>
    /// <param name="num"></param>
    void AddLevel(string name, int num)
    {
        LevelInfo li = new LevelInfo()
        {
            nameOfLevel = name,
            nameOfCreator = "Alec",
            filenameOfScene = "Level0" + num,
            imageForButton = sprites[num - 1] // get image from sprites
        };

        levelInfo.levels[num - 1] = li;
    }

    /// <summary>
    /// Instantiates a btnBack prefab
    /// Add event list
    /// </summary>
    void AddBackButton()
    {
        Vector3 pos = new Vector3(140, 530);
        Button btnBack = Instantiate(btnBackPrefab, pos, Quaternion.identity);

        // set parent
        btnBack.transform.parent = transform;

        // add event listener
        btnBack.onClick.AddListener(ButtonBack_Clicked);
    }

    /// <summary>
    /// Loads the Main Menu on click
    /// </summary>
    void ButtonBack_Clicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Adds 6 level buttons to the UI
    /// </summary>
    void AddLevelButtons()
    {
        AddLevelButton(530, 530, 1);
        AddLevelButton(530, 330, 2);
        AddLevelButton(530, 130, 3);
        AddLevelButton(1000, 530, 4);
        AddLevelButton(1000, 330, 5);
        AddLevelButton(1000, 130, 6);
    }

    /// <summary>
    /// Instantiates a btnLevel prefab
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="num"></param>
    void AddLevelButton(float x, float y, int num)
    {
        Vector3 pos = new Vector3(x, y); // location of button
        Button btn = Instantiate(btnLevelPrefab, pos, Quaternion.identity);
        btn.name = "btn" + num;

        // set parent
        btn.transform.parent = transform;

        // add event listener
        btn.onClick.AddListener(delegate { ButtonLevel_Clicked(num); });
        
        // set nameOfLevel on button text
        btn.GetComponentInChildren<Text>().text = levelInfo.levels[num - 1].nameOfLevel;

        // set image on button
        btn.image.sprite = levelInfo.levels[num - 1].imageForButton;
    }

    /// <summary>
    /// Loads scene when level button is clicked
    /// </summary>
    /// <param name="num"></param>
    void ButtonLevel_Clicked(int num)
    {
        SceneManager.LoadScene(levelInfo.levels[num - 1].filenameOfScene);
    }
}
