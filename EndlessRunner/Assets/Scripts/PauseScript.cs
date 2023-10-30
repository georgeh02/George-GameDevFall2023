using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public int gameMenuScene;
    [SerializeField] private float countdownLength = 3.0f;
    public bool countdownActive = false;
    public TextMeshProUGUI countdownText;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        StartCoroutine(CountDown());
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameMenuScene);
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    private IEnumerator CountDown()
    {
        countdownActive = true;
        float timer = countdownLength;
        countdownText.gameObject.SetActive(true);

        while (timer > 0)
        {
            countdownText.text = Mathf.Ceil(timer).ToString();
            yield return new WaitForSecondsRealtime(1.0f);
            timer--;
        }

        //countdownText.text = "0";
        countdownText.gameObject.SetActive(false);
        countdownActive = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

}
