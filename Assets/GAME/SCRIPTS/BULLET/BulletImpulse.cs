using UnityEngine;

public class BulletImpulse : MonoBehaviour
{
    private Rigidbody physics;

    [SerializeField] private float _force;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.velocity = transform.forward * _force;
    }
}
