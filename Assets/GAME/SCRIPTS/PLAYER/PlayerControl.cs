using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody physics;

    private float horizontal = 0;
    private float vertical = 0;

    Vector3 vec;

    [SerializeField] private float vel;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    [SerializeField] private float slope;

    float firetime = 0;

    [SerializeField] private float firetiming;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > firetime)
        {
            firetime = Time.time + firetiming;
            Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        vec = new Vector3(horizontal, 0, vertical);
        physics.velocity = vec * vel;

        physics.position = new Vector3(Mathf.Clamp(physics.position.x, minX, maxX), 0.0f, Mathf.Clamp(physics.position.z, minZ, maxZ));
        physics.rotation = Quaternion.Euler(0, 0, physics.velocity.x * -slope);
    }

}