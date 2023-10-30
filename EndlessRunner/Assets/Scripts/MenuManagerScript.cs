using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public int gameStartScene;
    public GameObject optionsMenuUI;

    private void Start()
    {
        optionsMenuUI.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    public void Settings()
    {
        optionsMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void LoadMenu()
    {
        optionsMenuUI.SetActive(false);
    }
}
