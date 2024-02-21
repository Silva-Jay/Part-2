using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    TextMeshProUGUI scoreLabel;
    float score;
    float highScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<TextMeshProUGUI>();
        scoreLabel.text = "Score: 0\nHigh Score: 0";
        highScore = PlayerPrefs.GetFloat("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score: " + score + "\nHigh Score: " + PlayerPrefs.GetFloat("highScore");
    }

    void addScore()
    {
        score += 1;

        if (score > PlayerPrefs.GetFloat("highScore"))
        {
            PlayerPrefs.SetFloat("highScore", score);
        }
    }

    void resetScore()
    {
        score = 0;
    }
}
