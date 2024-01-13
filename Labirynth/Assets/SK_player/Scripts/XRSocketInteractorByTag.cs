using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketInteractorByTag : XRSocketInteractor
{
    [SerializeField] private string _magazineTag;

    [System.Obsolete]
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.tag == _magazineTag;
    }
}
