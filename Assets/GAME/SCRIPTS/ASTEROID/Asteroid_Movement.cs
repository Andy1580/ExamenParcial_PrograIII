using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Movement : MonoBehaviour
{
    Rigidbody physics;
    
    [SerializeField] private float vel;
    
    void Start()
    {
        physics = GetComponent<Rigidbody>();

        physics.velocity = transform.forward * vel;
        physics.angularVelocity = Random.insideUnitSphere * vel;
    }
}
