using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LayerChange : MonoBehaviour
{
    [SerializeField] private string _off;
    [SerializeField] private string _on;
    public void IntLayerOff()
    {
        gameObject.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask(_off);
    }
    public void IntLayerOn()
    {
        gameObject.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask(_on);
    }
}
