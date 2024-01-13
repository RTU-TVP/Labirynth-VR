using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AnimateXRHands : MonoBehaviour
{
    [SerializeField] private InputActionProperty _pinchAP;
    [SerializeField] private InputActionProperty _grabAP;
    [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = _pinchAP.action.ReadValue<float>();
        float gripValue = _grabAP.action.ReadValue<float>();

        _animator.SetFloat("Trigger", triggerValue);
        _animator.SetFloat("Grip", gripValue);
    }
}
