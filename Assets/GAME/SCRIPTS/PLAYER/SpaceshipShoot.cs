using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShoot : MonoBehaviour
{
    float firetime = 0;

    [SerializeField] private float firetiming;
    
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time > firetime)
        {
            AudioManager.instance.PlaySound("WeapPlayer");
            firetime = Time.time + firetiming;
            Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
        }
    }
}
