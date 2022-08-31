using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject _pausePanel;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    private int levelsUnlocked;
    
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();

        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);
        for (int i = 0; i < _buttons.Length; i++)
        {
            //_buttons[i].interactable = false;
        }
        for (int i = 0; i < levelsUnlocked; i++)
        {
            _buttons[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    
    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked",currentLevel + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKey(KeyCode.Mouse0))
        {
            
            m_PointerEventData = new PointerEventData(m_EventSystem);
            
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            
            m_Raycaster.Raycast(m_PointerEventData, results);
            
            foreach (RaycastResult result in results)
            {
                
                if (result.gameObject.CompareTag("LevelCards") && result.gameObject.transform.GetChild(1).gameObject.activeSelf == false)
                {
                    PlayerPrefs.SetInt("CurrentLevel",Int32.Parse(result.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text));
                    Debug.Log("Hit " + result.gameObject.name);
                    SceneManager.LoadScene(Int32.Parse(result.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text));
                }
            }
        }
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(levelsUnlocked);
    }
    
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    
    public void Home()
    {
        SceneManager.LoadScene("Opening");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }
    
}
