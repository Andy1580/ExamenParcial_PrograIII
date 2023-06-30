using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Text _textScore;
    [SerializeField] public Text _textGameOver;
    [SerializeField] public Text _textRestart;

    private int _score;

    private void Start()
    {
        _score = 0;
        _textScore.text = "SCORE: " + _score;
        _score = 0;
    }

    public int Score
    {
        get => _score;
        private set => _score = value;
    }

    public void Scoring(int comingscore)
    {
        _score += comingscore;
        _textScore.text = "SCORE: " + _score;
    }
}
