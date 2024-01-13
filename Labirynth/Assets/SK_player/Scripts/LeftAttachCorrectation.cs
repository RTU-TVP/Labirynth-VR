using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftAttachCorrectation : MonoBehaviour
{
    [SerializeField] private Transform _attachPointR;
    [SerializeField] private Transform _attachPointL;
    [SerializeField] private XRGrabInteractable _interactor;
    [Space(10)]
    [SerializeField] private Transform _handR;
    [SerializeField] private Transform _handL;


    private void Update() 
    {
        if (Vector3.Distance(_attachPointL.position, _handL.position) > Vector3.Distance(_attachPointR.position, _handR.position))
        {
            _interactor.attachTransform = _attachPointL;
        }
        else _interactor.attachTransform = _attachPointR;
    }
}
