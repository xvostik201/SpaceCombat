using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverStatics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText, moneyText, highscoreText;


    GameManagerSystem gameManager;
    Score score;
    

    void Start()
    {
        gameManager = FindObjectOfType<GameManagerSystem>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = $"wave - {gameManager.waveValue}";
        moneyText.text = $"money Earned - {gameManager.moneyEarned}";
        highscoreText.text = $"highscore - {score.higscore}";
    }
}
