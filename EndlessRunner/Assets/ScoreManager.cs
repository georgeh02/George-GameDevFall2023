using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public float scoreCount;
    public float highScore;
    public GameObject player;

    public float pointsPerSecond;


    void Start()
    {
        if (PlayerPrefs.GetFloat("HighScore") != null)
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }
    }

    void Update()
    {

        scoreCount += (pointsPerSecond * player.GetComponent<PlayerMovement>().moveSpeed) * Time.deltaTime;

        scoreText.text = "Score: " + (int)scoreCount;

        if (scoreCount > PlayerPrefs.GetFloat("HighScore", 0))
        {
            highScore = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

        highScoreText.text = "High Score: " + (int)PlayerPrefs.GetFloat("HighScore", 0);

    }
}
