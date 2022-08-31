using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : Ball
{
    private Rigidbody2D _ballRb;
    [SerializeField] private float _redBallForce;
    // Start is called before the first frame update
    void Start()
    {
        _ballRb = GetComponent<Rigidbody2D>();
        _ballRb.velocity = Vector2.right * _redBallForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
