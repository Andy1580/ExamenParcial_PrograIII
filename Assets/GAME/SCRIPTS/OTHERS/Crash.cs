using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _playerExplosion;
    [SerializeField] private GameObject gM;

    private GameManager control;
    
    void Start()
    {
        gM = GameObject.FindGameObjectWithTag ("game_control");
        control = gM.GetComponent<GameManager> ();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "lines")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(_explosion, transform.position, transform.rotation);
            control.Scoring(10);
        }
        if (col.tag=="Player")
        {
            control.Scoring(-10);
            Instantiate(_playerExplosion, col.transform.position,col.transform.rotation);
            control.GameOver();
        }
    }
}
