using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, highscoreText, scoreTextInGame, highscoreTextInGame;

    [HideInInspector] public int score = 0, higscore;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            higscore = PlayerPrefs.GetInt("Highscore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(higscore < score) 
        {
            higscore = score;
            PlayerPrefs.SetInt("Highscore", higscore);
        }


        highscoreText.text = $"highscore - {higscore}";
        scoreText.text = $"Score - {score}";
        highscoreTextInGame.text = $"highscore - {higscore}";
        scoreTextInGame.text = $"Score - {score}";
    }
}
