using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene;

    public void StartGame(string scene) {

        SceneManager.LoadScene(scene);
    }

    public void QuitGame() {

        Application.Quit();
    }
}
