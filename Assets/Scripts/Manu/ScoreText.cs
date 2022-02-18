using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _score;
    void Start()
    {
        _score = 0;
    }

    public void AddScore(ScoreUpdate score)
    {
        _score += score.score;
        _scoreText.text = _score.ToString();
    }
}
