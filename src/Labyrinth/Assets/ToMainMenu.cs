using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainMenu : MonoBehaviour
{
    [SerializeField] string Name;
    public void Load()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(FindObjectOfType<SceneManagerScr>().LoadScene(Name));
    }
}
