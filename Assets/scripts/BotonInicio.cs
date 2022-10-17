using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonInicio : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("juego");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
