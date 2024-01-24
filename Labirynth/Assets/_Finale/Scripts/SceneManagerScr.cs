using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneManagerScr : MonoBehaviour
{
    public static SceneManagerScr Instance;

    [SerializeField] private Animator _fadeAnimator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
        SceneManager.sceneLoaded += scLoad;

    }

    void scLoad(Scene scene, LoadSceneMode mode)
    {
        _fadeAnimator = GameObject.FindGameObjectWithTag("FadeAnimator").GetComponent<Animator>();
    }

    void FadeIn(Scene scene, LoadSceneMode mode)
    {
        //_fadeAnimator.SetTrigger("Fadein");
    }

    public IEnumerator Fade()
    {
        _fadeAnimator.SetTrigger("Fadeout");
        yield return new WaitForSeconds(1f);
        _fadeAnimator.SetTrigger("Fadein");
    }
    
    public IEnumerator LoadScene(string name) 
    {
        _fadeAnimator.SetTrigger("Fadeout");
        yield return new WaitForSeconds(1f);
        LoadSceneAsyn(name);
    }
    private async void LoadSceneAsyn(string name)
    {
        var scene = SceneManager.LoadSceneAsync(name);
        scene.allowSceneActivation = true;

    }

}
