using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    #region VAR
    Rigidbody2D _playerRb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameManager managerGame;
    public Animator animator;
    public bool isLeftRunning;
    public bool isRightRunning;
    [SerializeField] public Sprite[] _whichGun;
    float speed = 10f;
    private Vector3 pos;
    private SpriteRenderer _image;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _image = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void MoveLeft()
    {
        isLeftRunning = true;
        
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void MoveRight()
    {
        //_playerRb.velocity = Vector2.right * _moveSpeed;
        isRightRunning = true;
        
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void StopMoving()
    {
        _playerRb.velocity = Vector2.zero;
        
        if (isLeftRunning)
        {
            isLeftRunning = false;
        }
        if (isRightRunning)
        {
            isRightRunning = false;
        }
        animator.SetBool("IsPlayerLeftGoing",isLeftRunning);
        animator.SetBool("IsPlayerRightGoing",isRightRunning);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            managerGame.DeadCheck();
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            Debug.Log("Kalbe carpti");
            managerGame.HealthCheck();
            Destroy(collision.gameObject,0f);
        }

        if (collision.gameObject.CompareTag(("Bullet2")))
        {
            Gun._whichBullet = 1;
            _image.sprite = _whichGun[1];
            managerGame.BulletCheck();
            Destroy(collision.gameObject,0f);
        }
        
        if (collision.gameObject.CompareTag(("Bullet3")))
        {
            
            Gun._whichBullet = 2;
            managerGame.BulletCheck();
            Destroy(collision.gameObject,0f);
           
        }
        
    }

   

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
                if (Input.GetKey ("d")) {
                    pos.x += speed * Time.deltaTime;
                }
                if (Input.GetKey ("a")) {
                    pos.x -= speed * Time.deltaTime;
                }
                transform.position = pos;
                
                animator.SetBool("IsPlayerLeftGoing",isLeftRunning);
                animator.SetBool("IsPlayerRightGoing",isRightRunning);
                
                if (isLeftRunning)
                {
                    transform.position += new Vector3(-1, 0) * _moveSpeed * Time.deltaTime;
                   
                }

                if (isRightRunning)
                {
                    //transform.position += transform.right * Time.deltaTime * _moveSpeed;
                    transform.position += new Vector3(1, 0) * _moveSpeed * Time.deltaTime;
                    
                }
    }
}
