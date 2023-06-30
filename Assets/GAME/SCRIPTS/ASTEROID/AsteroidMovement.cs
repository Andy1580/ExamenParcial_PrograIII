using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Rigidbody physics;
    
    [SerializeField] private float _asteroidSpeed;
    [SerializeField] private float _asteroidRotation;
    
    void Start()
    {
        physics = GetComponent<Rigidbody>();

        AsteroidMove();
        AsteroidRotation();
    }

    void AsteroidMove()
    {
        physics.velocity = transform.forward * _asteroidSpeed;
    }

    void AsteroidRotation()
    {
        physics.angularVelocity = Random.insideUnitSphere * _asteroidRotation;
    }
}
