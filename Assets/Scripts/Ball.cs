using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{

     #region VAR
    
    [SerializeField] private int _ballLevel;
    [SerializeField] private int _crackPartCount;
    [SerializeField] private GameObject[] _afterBall;
    [SerializeField] private GameObject[] _dropItem;
    [SerializeField] private float _ballSpeed;
    [SerializeField] private float[] _ballStartForce;
    [SerializeField] private int _ballLife;
    #endregion

    #region GETTERS N SETTERS

    public int Get_BallLevel()
    {
        return _ballLevel;
    }

    public void Set_BallLevel(int _ballLevel)
    {
        this._ballLevel = _ballLevel;
    }

    public int Get_CrackPartCount()
    {
        return _crackPartCount;
    }

    public void Set_CrackPartCount(int _crackPartCount)
    {
        this._crackPartCount = _crackPartCount;
    }
    
    public int Get_BallLife()
    {
        return _ballLife;
    }
    
    public void Set_BallLife(int _ballLife)
    {
        this._ballLife = _ballLife;
    }

    public GameObject Get_AfterBall()
    {
        return _afterBall[0];
    }

    public void Set_AfterBall(GameObject _afterBall)
    {
        //this._afterBall = _afterBall[0];
    }
    
    public float Get_BallSpeed()
    {
        return _ballSpeed;
    }

    public void Set_CrackPartCount(float _ballSpeed)
    {
        this._ballSpeed = _ballSpeed;
    }

    public float Get_BallStartForce()
    {
        return _ballStartForce[0];
    }
    
    #endregion

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Bullet2") || collision.gameObject.CompareTag("Bullet3"))
        {
            _ballLife--;
            Destroy(collision.gameObject);
            //gameObject.GetComponent<TextMeshPro>();
            if (_ballLife < 1)
            {
                AfterBall();
                Destroy(gameObject);
            }
            
        }

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce( new Vector3(3f,0,0),ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-3f,0,0),ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,11,0),ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
    
    private void AfterBall()
    {
        if (_afterBall.Length == 0) {
            Console.WriteLine("array is empty");
        }else{
            int i = 0;
            while (i < 2)
            {
                GameObject bll = Instantiate(_afterBall[i], gameObject.transform.position, transform.rotation);
                bll.GetComponent<Rigidbody2D>().velocity = Vector2.right * _ballStartForce[i];
                i++;

                int randx = Random.Range(0, 10);
                if (randx < 3)
                {
                    int randItem = Random.Range(0,_dropItem.Length);
                    GameObject itm = Instantiate(_dropItem[randItem], gameObject.transform.position, transform.rotation);
                }
            }
        }
    }
    private void Start()
    {
        _ballLife = Random.Range(2, 10);
    }
    
   
    
    public void BallStop()
    {
        Debug.Log("Top durmali");
        gameObject.GetComponent<Rigidbody2D>().simulated = false;

    }
}