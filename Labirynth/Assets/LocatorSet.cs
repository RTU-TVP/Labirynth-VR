using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LocatorSet : MonoBehaviour
{
    GameObject _locator;
    bool _locatorActive;
    [SerializeField] private InputActionReference InputLocator;
    [SerializeField] private InputActionReference Walk;
    void Start()
    {
        _locator = GameObject.FindObjectOfType<Locator>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputLocator.action.triggered) { _locatorActive = true; }
        while (_locatorActive)
        {
            if (Walk.action.ReadValue<Vector2>() == Vector2.zero) { _locatorActive = false; }
           _locator.SetActive(_locatorActive);
        }
    }
}
