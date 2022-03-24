using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseScreen;
    public bool isPaused;

    void Start()
    {
        isPaused = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Menu")) {

            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {

        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
