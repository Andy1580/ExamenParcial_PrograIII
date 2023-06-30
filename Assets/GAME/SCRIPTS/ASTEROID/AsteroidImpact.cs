using UnityEngine;

public class AsteroidImpact : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject playerExplosion;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            GameManager.Instance.Scoring(10);
        }

        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
            Instantiate(playerExplosion, col.transform.position, col.transform.rotation);
            GameManager.Instance.GameOver();
        }
    }
}
