using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _asteroid;

    [SerializeField] private Vector3 _randomPos;

    [SerializeField] private float _startWaiting;
    [SerializeField] private float _createWaiting;
    [SerializeField] private float _loopWaiting;

    bool _gameOverControl = false;

    private bool _restart = false;

    void Start()
    {
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
}
