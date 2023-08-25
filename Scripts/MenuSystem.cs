using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] menuButtons;
    [SerializeField] private GameObject mainMenu, pauseMenu, allMenu, settingMenu;

    GameManagerSystem manager;
    private bool inPause = false;


    void Start()
    {
        manager = FindObjectOfType<GameManagerSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !manager.gameIsStarted) 
        {
            ReturnToMainMenu();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && manager.gameIsStarted && !inPause)
        {
            PauseMenuOn();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && manager.gameIsStarted && inPause)
        {
            PauseMenuOff();
        }

    }

    

    public void Settings()
    {

    }
    public void Play()
    {
        manager.StartGame();
    }
    public void Shop()
    {

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ReturnToMainMenu()
    {
        foreach (GameObject gameObject in menuButtons)
        {
            gameObject.SetActive(false);
        }
            mainMenu.SetActive(true);
    }

    public void PauseMenuOn()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        allMenu.SetActive(true);
        inPause = true;
    }
    public void PauseMenuOff()
    {
        pauseMenu.SetActive(false);
        allMenu.SetActive(false);
        settingMenu.SetActive(false);
        Time.timeScale = 1f;
        inPause = false;
    }
}
