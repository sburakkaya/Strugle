using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region VAR
    [SerializeField] private int _lives;
    [SerializeField] TMP_Text _livesText;
    [SerializeField] public Sprite[] _whichGun;
    private GameObject[] balls;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private bool _winCheck;
    [SerializeField] private Image timerBar;
    [SerializeField] private float maxTime;
    [SerializeField] GameObject _left;
    [SerializeField] GameObject _right;
    [SerializeField] GameObject _heartImg;
    [SerializeField] GameObject _gunImg;
    [SerializeField] GameObject _timeBar;
    [SerializeField] GameObject _pauseButton;
    private Image image;
    private float timeLeft;
    #endregion
    private void Start()
    {
        Time.timeScale = 1;
        Game.isPlaying = true;
        _livesText = GameObject.Find("HealthText").GetComponent<TMP_Text>();
        timerBar = timerBar.GetComponent<Image>();
        timeLeft = maxTime;
        image = GameObject.Find("GunImg").GetComponent<Image>();
    }

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    public void DeadCheck()
    {
        _lives--;
        _livesText.text = _lives.ToString("F0");
        if (_lives < 1)
        {
            Debug.Log("isplaying f");
            Game.isPlaying = false;
            IsPlaying();
            _loseScreen.SetActive(true);
        }
    }

    public void IsPlaying()
    {
        if (!Game.isPlaying)
        {
            _left.SetActive(false);
            _right.SetActive(false);
            //_fire.SetActive(false);
            _livesText.gameObject.SetActive(false);
            _heartImg.SetActive(false);
            _gunImg.SetActive(false);
            _timeBar.SetActive(false);
            _pauseButton.SetActive(false);
                
            balls = GameObject.FindGameObjectsWithTag("Ball");
            
            foreach (var ball in balls)
            {
                ball.gameObject.GetComponent<Ball>().BallStop();
            }
                
        }
    }

    public void WinCheck()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length == 0 && _winCheck == false && Game.isPlaying == true)
        {
            Debug.Log("Oyunu kazandiniz");
            _winCheck = true;
            Game.isPlaying = false;
            IsPlaying();
            _winScreen.SetActive(true);
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }
    }

    public void HealthCheck()
    {
        _lives++;
        _livesText.text = _lives.ToString("F0");
    }

    public void BulletCheck()
    {
        if (Gun._whichBullet == 0)
        {
            image.sprite = _whichGun[0];
        }

        if (Gun._whichBullet == 1)
        {
            image.sprite = _whichGun[1];
        }
        if (Gun._whichBullet == 2)
        {
            image.sprite = _whichGun[2];
        }
    }

    private void Update()
    {
        WinCheck();
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            
        }
        else if(Game.isPlaying)
        {
            _lives = 1;
            DeadCheck();
        }
    }
}
