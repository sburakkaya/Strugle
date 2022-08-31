using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    #region VAR
    [SerializeField] private List<GameObject> _bullet;
    public static int _whichBullet;
    [SerializeField] private GameObject _gun2;
    [SerializeField] private GameObject _gunMiner;
    private bool cooldown = false;
    [SerializeField] private GameManager _gameManager;
    //public Animator animator;
    public bool isFired;
    public bool isMineFired;
    #endregion
    
    void Start()
    {
        _whichBullet = 0;
        StartCoroutine(Cooldown());
    }

    public void SpawnBullet()
    {
        
        if (!cooldown && Game.isPlaying)
        {
            if (_whichBullet == 0)
            {
                isFired = true;
                Vector3 _position = this.gameObject.transform.position;
                GameObject blt =  Instantiate(_bullet[0], _position, Quaternion.Euler(0,0,0));
                //animator.SetBool("IsFired",isFired);
            }

            if (_whichBullet == 1)
            {
                _gunMiner.SetActive(true);
                isMineFired = true;
                Vector3 _position3 = _gunMiner.transform.position;
                GameObject blt =  Instantiate(_bullet[1], _position3, Quaternion.Euler(0,0,0));
                //animator.SetBool("IsMineFired",isMineFired);
            }
            if (_whichBullet == 2)
            {
                _gun2.SetActive(true);
                Vector3 _position = this.gameObject.transform.position;
                GameObject blt =  Instantiate(_bullet[2], _position, Quaternion.Euler(0,0,0));
                Vector3 _position2 = _gun2.transform.position;
                GameObject blt2 =  Instantiate(_bullet[2], _position2, Quaternion.Euler(0,0,0));

            }
            
            cooldown = true;
            StartCoroutine(Cooldown());
        }
           

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isFired = false;
        isMineFired = false;
        /*animator.SetBool("IsFired",isFired);
        animator.SetBool("IsMineFired",isMineFired);*/
        yield return new WaitForSeconds(0.3f);
        cooldown = false;
        SpawnBullet();
        //_gameManager.WinCheck();
    }
}
