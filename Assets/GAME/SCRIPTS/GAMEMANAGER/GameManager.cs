using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    [Header("Texts")]
    [SerializeField] Text scoreText;
    [SerializeField] Text gameOverText;
    [SerializeField] Text restartText;

    int score;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        AudioManager.instance.PlaySound("SoundTrack");
        score = 0;
        scoreText.text = "SCORE: " + score;
        gameOverText.text = "";
        restartText.text = "";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Scoring(int scoreIncrease)
    {
        score += scoreIncrease;
        scoreText.text = "SCORE: " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "GAME OVER!";
        restartText.text = "For Restart Press R";
    }
}
