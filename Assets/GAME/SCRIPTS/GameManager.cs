using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreSystem _scoreSystem;

    bool _gameOverControl = false;

    private void Start()
    {
        _scoreSystem = GetComponent<ScoreSystem>();
    }

    public void GameOver()
    {
        _scoreSystem._textGameOver.text = "GAME OVER !";
        _scoreSystem._textRestart.text = "For Restart Press R :)";
        _gameOverControl = true;
    }

}
