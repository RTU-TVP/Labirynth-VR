using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScr : MonoBehaviour
{
    public static SceneManagerScr Instance;

    [SerializeField] private GameObject _loaderCanv;
    [SerializeField] private Animator _fadeAnimator;
    [SerializeField] private Slider _loadingBar;
    [SerializeField] private float _loadTimer;
    [SerializeField] private bool _loadComplete;
    [SerializeField] private float _target;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

    }

    public IEnumerator LoadScene(string name) 
    {
        _loadComplete = false;
        _fadeAnimator.SetTrigger("Fadeout");
        yield return new WaitForSeconds(1f);
        LoadSceneAsyn(name);
        while (!_loadComplete) { yield return null; }
        yield return new WaitForSeconds(0.1f);
        _fadeAnimator.SetTrigger("Fadein");
    }
    private async void LoadSceneAsyn(string name)
    {
        _loadingBar.value = 0;

        var scene = SceneManager.LoadSceneAsync(name);
        scene.allowSceneActivation = false;

        _loaderCanv.SetActive(true);
        _loadTimer = 0;
        do 
        {
            await Task.Delay(100);
            _target = scene.progress;
            if (scene.progress == 0.9f && _loadTimer >= 2f)
            {
                _loadComplete= true;
                scene.allowSceneActivation = true;
            }
        } 
        while (scene.progress < 1f);
        _loaderCanv.SetActive(false);
    }

    private void Update()
    {
        _loadingBar.value = Mathf.MoveTowards(_loadingBar.value, _target, 2 * Time.deltaTime);
        if (_loadTimer < 2) { _loadTimer += Time.deltaTime; }
    }
}
