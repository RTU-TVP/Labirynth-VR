using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainMenu : MonoBehaviour
{
    [SerializeField] string Name;
    public void Load()
    {
        if (Name == "") { Name = "MainMenu"; }
        Time.timeScale = 1.0f;
        StartCoroutine(FindAnyObjectByType<SceneManagerScr>().LoadScene(Name));
    }
}
