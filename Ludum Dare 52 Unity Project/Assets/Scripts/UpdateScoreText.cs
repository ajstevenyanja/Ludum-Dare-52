using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UpdateScoreText : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] UnityEvent OnReachingMaxScore;

    int tomatoePerPlant = 3;
    int score = 0;
    int maxScore;

    private void Start()
    {
        maxScore = GameObject.FindGameObjectsWithTag("Plant").Length * tomatoePerPlant;
        scoreText.text = $"{score} / {maxScore}";
    }

    public void UpdateScore()
    {
        score += tomatoePerPlant;
        scoreText.text = $"{score} / {maxScore}";

        if (score == maxScore)
        {
            OnReachingMaxScore.Invoke();
        }
    }
}
