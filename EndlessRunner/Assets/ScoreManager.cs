using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float scoreCount;
    public GameObject player;

    public float pointsPerSecond;


    void Start()
    {
    }

    void Update()
    {
        scoreCount += (pointsPerSecond * player.GetComponent<PlayerMovement>().moveSpeed) * Time.deltaTime;

        scoreText.text = "Score: " + (int)scoreCount;
    }
}
