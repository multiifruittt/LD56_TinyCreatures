using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private List<GameObject> ui;
    private bool _isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
               Continue();
            }
            else
            {
               PauseGame();
            }
        }
    }
    public void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        foreach (GameObject item in ui)
        {
            item.SetActive(true);
        }
    }
    public void PauseGame()
    {
        
        panel.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        foreach (GameObject item in ui) 
        {
            item.SetActive(false);
        }
    }
}
