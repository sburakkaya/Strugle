using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BigBall : Ball
{
    private Rigidbody2D _ballRb;
    [SerializeField] private float _bigBallForce;
    private TextMeshPro _lifeTMP;

    // Start is called before the first frame update
    void Start()
    {
        _ballRb = GetComponent<Rigidbody2D>();
        _ballRb.velocity = Vector2.right * _bigBallForce;
        
        Set_BallLife(Random.Range(2, 10));

        _lifeTMP = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        _lifeTMP.text = Get_BallLife().ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
        _lifeTMP.text = Get_BallLife().ToString();
    }
    

    
    private void FixedUpdate()
    {
        
    }
}
