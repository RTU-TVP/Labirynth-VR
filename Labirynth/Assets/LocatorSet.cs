using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LocatorSet : MonoBehaviour
{
    Locator _locator;
    [SerializeField] private InputActionReference InputLocator;
    [SerializeField] private InputActionReference Walk;
    void Start()
    {
        _locator = FindObjectOfType<Locator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputLocator.action.triggered && Walk.action.ReadValue<Vector2>() == Vector2.zero) { _locator.enabled = true; }
        if (Walk.action.ReadValue<Vector2>() != Vector2.zero)
        {
            _locator.enabled = false;
        }
    }
}
