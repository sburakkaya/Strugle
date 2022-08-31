using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _bulletRb;
    [SerializeField] private float _bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _bulletRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        _bulletRb.AddForce(transform.up * _bulletSpeed);
    }
}
