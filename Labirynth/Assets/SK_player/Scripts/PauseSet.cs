using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseSet : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private Transform _camera;
    [SerializeField] private InputActionReference InputPause;
    

    public void SetPause()
    {
        PauseUI.SetActive(true);
        PauseUI.transform.position = _camera.position + new Vector3(_camera.forward.x, 0, _camera.forward.z).normalized * 2;
        PauseUI.transform.LookAt(new Vector3(_camera.position.x, PauseUI.transform.position.y, _camera.position.z));
        PauseUI.transform.forward *= -1;

        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (InputPause.action.triggered || Input.GetKeyDown(KeyCode.P)) { SetPause(); }
    }
}
