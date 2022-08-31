using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMine : MonoBehaviour
{
    private GameObject Player;
    Rigidbody2D _bulletRb;
    [SerializeField] private float _bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _bulletRb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("plyr");
        Destroy(gameObject,7f);
        if(Player.transform.rotation.y < 0)
        {
            _bulletRb.AddForce(transform.right * _bulletSpeed * -1);
        }
        if (Player.transform.rotation.y == 0)
        { 
            _bulletRb.AddForce(transform.right * _bulletSpeed);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
