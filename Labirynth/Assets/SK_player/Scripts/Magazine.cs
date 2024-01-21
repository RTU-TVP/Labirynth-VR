using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Magazine : MonoBehaviour
{
    public int bulletsCount;

    public void IntLayerOff() 
    {
        gameObject.GetComponent<XRGrabInteractable>().interactionLayers = LayerMask.GetMask("Default"); //.GetOldestInteractableSelected();
    }
    public void IntLayerOn() 
    {
        gameObject.GetComponent<XRGrabInteractable>().interactionLayers = LayerMask.GetMask("Gun Magazine");
    }
}
