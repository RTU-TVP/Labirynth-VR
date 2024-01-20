using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScr : MonoBehaviour
{
    public static SceneManagerScr Instance;

    [SerializeField] private GameObject _loaderCanv;
    [SerializeField] private Slider _loadingBar;
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

    public async void LoadScene(string name)
    {
        _loadingBar.value = 0;
        var scene = SceneManager.LoadSceneAsync(name);
        scene.allowSceneActivation = true;

        _loaderCanv.SetActive(true);

        do 
        {
            await Task.Delay(100);
            _target = scene.progress;
        } 
        while (scene.progress < 1f);

        _loaderCanv.SetActive(false);
    }

    private void Update()
    {
        _loadingBar.value = Mathf.MoveTowards(_loadingBar.value, _target, 3 * Time.deltaTime);

    }
}
