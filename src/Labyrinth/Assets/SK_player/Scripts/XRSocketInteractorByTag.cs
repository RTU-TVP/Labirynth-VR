using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketInteractorByTag : XRSocketInteractor
{
    [SerializeField] private string[] _tag;

    [System.Obsolete]
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        foreach (var tag in _tag) {
            if (interactable.tag == tag) return base.CanSelect(interactable);
        }
        return false;
    }
}
