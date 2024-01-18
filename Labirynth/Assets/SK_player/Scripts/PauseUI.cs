using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public void Continue()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
    public void Quit()
    {
        Time.timeScale = 1.0f;
        //SceneManager.LoadScene("Main Menu");
    }
}