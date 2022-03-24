using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseScreen;
    private bool isPaused;

    void Start()
    {
        PauseUnpause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {

        if (isPaused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void resume (){

        pauseScreen.SetActive(false);
            Time.timeScale = 1;
    }

    public void volverInicio(string scene) {

        SceneManager.LoadScene(scene);
    }
}
