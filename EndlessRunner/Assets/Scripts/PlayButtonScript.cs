using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{

    public int gameStartScene;

    public void StartGame()
    {
        PauseScript.GameIsPaused = false;
        SceneManager.LoadScene(gameStartScene);
    }
}
