using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    Rigidbody physics;

    private float horizontal = 0;
    private float vertical = 0;

    Vector3 vec;

    [SerializeField] private float _speed;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minZ;
    [SerializeField] private float _maxZ;
    [SerializeField] private float slope;

    

    void Start()
    {
        physics = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        vec = new Vector3(horizontal, 0, vertical);
        physics.velocity = vec * _speed;

        physics.position = new Vector3(Mathf.Clamp(physics.position.x, _minX, _maxX), 0.0f, Mathf.Clamp(physics.position.z, _minZ, _maxZ));
        physics.rotation = Quaternion.Euler(0, 0, physics.velocity.x * -slope);

    }



}