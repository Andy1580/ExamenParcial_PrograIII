using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _playerExplosion;

    ScoreSystem _scoreringMethod;

    GameManager _gameOverMethod;
    
    void Start()
    {
        _scoreringMethod = GetComponent<ScoreSystem>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "lines")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(_explosion, transform.position, transform.rotation);
            _scoreringMethod.Scoring(10);
        }
        if (col.tag=="Player")
        {
            _scoreringMethod.Scoring(-10);
            Instantiate(_playerExplosion, col.transform.position,col.transform.rotation);
            _gameOverMethod.GameOver();
        }
    }
}
