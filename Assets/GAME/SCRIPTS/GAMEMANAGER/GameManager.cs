using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _asteroid;

    [SerializeField] private Vector3 _randomPos;

    [SerializeField] private float _startWaiting;
    [SerializeField] private float _createWaiting;
    [SerializeField] private float _loopWaiting;

    [SerializeField] private Text _textScore;
    [SerializeField] private Text _textGameOver;
    [SerializeField] private Text _textRestart;

    bool _gameOverControl = false;

    private int _score;

    private bool _restart = false;

    void Start()
    {
        _score = 0;
        _textScore.text = "SCORE: " + _score;
        _score = 0;
        StartCoroutine(RandomCreate());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("level1");
        }
    }

    public bool Restart
    {
        get => _restart;
        private set => _restart = value;
    }

    public int Score
    {
        get =>_score;
        private set => _score = value;
    }

    IEnumerator RandomCreate()
    {

        yield return new WaitForSeconds(_startWaiting);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-_randomPos.x, _randomPos.x), 0, _randomPos.z);
                Instantiate(_asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(_loopWaiting);
            }
            
            if (_gameOverControl)
            {
                _restart = true;
                break;
            }
           
            yield return new WaitForSeconds(_createWaiting);
        }

    }

    public void Scoring(int comingscore)
    {
        _score += comingscore;
        _textScore.text = "SCORE: " + _score;
    }

    public void GameOver()
    {
        _textGameOver.text = "GAME OVER !";
        _textRestart.text = "For Restart Press R :)";
        _gameOverControl = true;
    }
}
