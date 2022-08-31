using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MediumBall : Ball
{
    private TextMeshPro _lifeTMP;
    // Start is called before the first frame update
    void Start()
    {
        Set_BallLife(Random.Range(2, 10));
        
        _lifeTMP = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        _lifeTMP.text = Get_BallLife().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _lifeTMP.text = Get_BallLife().ToString();
    }
}
